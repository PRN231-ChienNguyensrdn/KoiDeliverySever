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

		// Constructor that ensures context is injected
		public UnitOfWork(KoiDeliveryDBContext context)
		{
			_context = context ?? throw new ArgumentNullException(nameof(context));
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

		// Implement the PriceListRepo property
		public PriceListRepo PriceListRepo
		{
			get
			{
				return _priceListRepo ??= new PriceListRepo(_context);  // Lazy initialization of PriceListRepo
			}
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
