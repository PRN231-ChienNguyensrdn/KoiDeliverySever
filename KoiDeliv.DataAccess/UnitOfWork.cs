using KoiDeliv.DataAccess.Models;
using KoiDeliv.DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
	public class UnitOfWork : IUnitOfWork, IDisposable
	{
		private readonly KoiDeliveryDBContext _context;  // Use readonly to prevent accidental changes
		private PriceListRepo _priceListRepo;
		private OrderRepo _orderRepo;
		private RatingsFeedbackRepo _ratingsFeedbackRepo;
		private UserRepo _userRepo;
		private ShipmentRepo _shipmentRepo;

		// Constructor that ensures context is injected
		public UnitOfWork(KoiDeliveryDBContext context)
		{
			_context = context ?? throw new ArgumentNullException(nameof(context));
		}

		public UserRepo UserRepo
		{
			get
			{
				return _userRepo ??= new UserRepo(_context);
			}
		}

		public RatingsFeedbackRepo RatingsFeedbackRepo
		{
			get
			{
				return _ratingsFeedbackRepo ??= new RatingsFeedbackRepo(_context);
			}
		}


		public ShipmentRepo ShipmentRepo
		{
			get
			{
				return _shipmentRepo ??= new ShipmentRepo(_context);
			}
		}
		public OrderRepo OrderRepo
		{
			get
			{
				return _orderRepo ??= new OrderRepo(_context);
			}
		}

		// Implement the PriceListRepo property
		public PriceListRepo PriceListRepo
		{
			get
			{
				return _priceListRepo ??= new PriceListRepo(_context);  // Lazy initialization of PriceListRepo
			}
		}
		

		// Save method with validation logic
		public void Save()
		{
			var validationErrors = _context.ChangeTracker.Entries<IValidatableObject>()
				.SelectMany(e => e.Entity.Validate(null))
				.Where(e => e != ValidationResult.Success)
				.ToArray();
			if (validationErrors.Any())
			{
				var exceptionMessage = string.Join(Environment.NewLine,
					validationErrors.Select(error => $"Properties {error.MemberNames} Error: {error.ErrorMessage}"));
				throw new Exception(exceptionMessage);
			}
			_context.SaveChanges();
		}

	

		// Dispose method to release resources
		private bool _disposed = false;
		protected virtual void Dispose(bool disposing)
		{
			if (!_disposed)
			{
				if (disposing)
				{
					_context.Dispose();
				}
				_disposed = true;
			}
		}

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}
	}
}
