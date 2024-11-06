using AutoMapper;
using Business.Base;
using Common;
using KoiDeliv.DataAccess.Models;
using KoiDeliv.Service.DTO.Create;
using KoiDeliv.Service.DTO.Update;
using KoiDeliv.Service.Interface;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace KoiDeliv.Service.Implementations
{
	public class OrderService : IOrderService
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;

		public OrderService(IUnitOfWork unitOfWork, IMapper mapper)
		{
			_unitOfWork = unitOfWork;
			_mapper = mapper;
		}

		public bool Delete(object id)
		{
			throw new NotImplementedException();
		}

		public void Delete(Order entityToDelete)
		{
			throw new NotImplementedException();
		}

		public async Task<IBusinessResult> DeleteById(int id)
		{
			try
			{
				var order = await _unitOfWork.OrderRepo.GetByIdAsync(id);
				if (order != null)
				{
					bool result = await _unitOfWork.OrderRepo.RemoveAsync(order);
					if (result)
					{
						return new BusinessResult(Const.SUCCESS_DELETE_CODE, Const.SUCCESS_DELETE_MSG);
					}
					return new BusinessResult(Const.FAIL_DELETE_CODE, Const.FAIL_DELETE_MSG);
				}

				return new BusinessResult(Const.WARNING_NO_DATA_CODE, Const.WARNING_NO_DATA_MSG);
			}
			catch (Exception ex)
			{
				return new BusinessResult(Const.ERROR_EXCEPTION, ex.ToString());
			}
		}

		public IEnumerable<Order> Get(Expression<Func<Order, bool>>? filter = null, Func<IQueryable<Order>, IOrderedQueryable<Order>>? orderBy = null, string includeProperties = "", int? pageIndex = null, int? pageSize = null)
		{
			throw new NotImplementedException();
		}

		public async Task<IBusinessResult> GetAll()
		{
			try
			{
				var orders = await _unitOfWork.OrderRepo.GetAllAsync();

				if (orders == null || !orders.Any())
				{
					return new BusinessResult(Const.WARNING_NO_DATA_CODE, Const.WARNING_NO_DATA_MSG);
				}

				return new BusinessResult(Const.SUCCESS_READ_CODE, Const.SUCCESS_READ_MSG, orders);
			}
			catch (Exception ex)
			{
				return new BusinessResult(Const.ERROR_EXCEPTION, ex.Message);
			}
		}

        public async Task<IBusinessResult> GetAllOrderCustomer(string uid)
        {
            try
            {
                var orders = await _unitOfWork.OrderRepo.getOrderUser(Int32.Parse(uid));

                if (orders == null || !orders.Any())
                {
                    return new BusinessResult(Const.WARNING_NO_DATA_CODE, Const.WARNING_NO_DATA_MSG);
                }

                return new BusinessResult(Const.SUCCESS_READ_CODE, Const.SUCCESS_READ_MSG, orders);
            }
            catch (Exception ex)
            {
                return new BusinessResult(Const.ERROR_EXCEPTION, ex.Message);
            }
        }

        public Order GetByID(object id)
		{
			throw new NotImplementedException();
		}

		public async Task<IBusinessResult> GetById(int id)
		{
			try
			{
				var order = await _unitOfWork.OrderRepo.GetByIdAsync(id);

				if (order == null)
				{
					return new BusinessResult(Const.WARNING_NO_DATA_CODE, Const.WARNING_NO_DATA_MSG);
				}
				else
				{
					return new BusinessResult(Const.SUCCESS_READ_CODE, Const.SUCCESS_READ_MSG, order);
				}
			}
			catch (Exception ex)
			{
				return new BusinessResult(Const.ERROR_EXCEPTION, ex.Message);
			}
		}

		public void Insert(Order entity)
		{
			throw new NotImplementedException();
		}

		public async Task<IBusinessResult> Save(CreateOrderDTO orderDTO)
		{
			try
			{
				Order newOrder = _mapper.Map<Order>(orderDTO);

				int result = await _unitOfWork.OrderRepo.CreateAsync(newOrder);
				if (result > 0)
				{
					return new BusinessResult(Const.SUCCESS_CREATE_CODE, Const.SUCCESS_CREATE_MSG);
				}
				else
				{
					return new BusinessResult(Const.FAIL_CREATE_CODE, Const.FAIL_CREATE_MSG);
				}
			}
			catch (Exception ex)
			{
				return new BusinessResult(Const.ERROR_EXCEPTION, ex.ToString());
			}
		}

		public bool Update(object id, Order entityToUpdate)
		{
			throw new NotImplementedException();
		}

		public void Update(Order entityToUpdate)
		{
			throw new NotImplementedException();
		}

		public async Task<IBusinessResult> Update(UpdateOrderDTO orderDTO)
		{
			try
			{
				var existOrder = await _unitOfWork.OrderRepo.GetByIdAsync(orderDTO.OrderId);
				if (existOrder == null)
				{
					return new BusinessResult(Const.FAIL_UPDATE_CODE, "Order not found");
				}

				existOrder.Origin = orderDTO.Origin ?? existOrder.Origin;
				existOrder.Destination = orderDTO.Destination ?? existOrder.Destination;
				existOrder.TotalWeight = orderDTO.TotalWeight;
				existOrder.TotalQuantity = orderDTO.TotalQuantity;
				existOrder.ShippingMethod = orderDTO.ShippingMethod ?? existOrder.ShippingMethod;
				existOrder.Status = orderDTO.Status ?? existOrder.Status;
				existOrder.AdditionalServices = orderDTO.AdditionalServices ?? existOrder.AdditionalServices;

				int result = await _unitOfWork.OrderRepo.UpdateAsync(existOrder);
				if (result > 0)
				{
					return new BusinessResult(Const.SUCCESS_UPDATE_CODE, Const.SUCCESS_UPDATE_MSG);
				}
				else
				{
					return new BusinessResult(Const.FAIL_UPDATE_CODE, Const.FAIL_UPDATE_MSG);
				}
			}
			catch (Exception ex)
			{
				return new BusinessResult(Const.ERROR_EXCEPTION, ex.ToString());
			}
		}
	}
}
