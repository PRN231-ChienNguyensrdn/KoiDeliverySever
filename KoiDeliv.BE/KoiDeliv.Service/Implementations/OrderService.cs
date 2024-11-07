using AutoMapper;
using Business.Base;
using Common;
using KoiDeliv.DataAccess.Models;
using KoiDeliv.Service.DTO.Create;
using KoiDeliv.Service.DTO.Update;
using KoiDeliv.Service.Interface;
using KoiDeliv.Service.VNPAY;
using Microsoft.Extensions.Configuration;
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
        private readonly IConfiguration _configuration;

        public OrderService(IUnitOfWork unitOfWork, IMapper mapper, IConfiguration configuration)
		{
			_unitOfWork = unitOfWork;
			_mapper = mapper;
			_configuration = configuration;
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


        /*public async Task<string> CreateOrder(List<OrderProductDto> cartItems)
        {
            using (var transaction = await _unitOfWork.BeginTransactionAsync())
            {
                try
                {
                    decimal totalPrice = 0;
                    int customerId = cartItems[0].CustomerId;
                    List<OrderDetailDtoRequest> orderProducts = new List<OrderDetailDtoRequest>();
                    foreach (var cartItem in cartItems)
                    {
                        var product = await _unitOfWork.ProductRepository.GetByIDAsync(cartItem.ProductId);
                        totalPrice += (product.Price * cartItem.Quantity);
                        var orderProduct = new OrderDetailDtoRequest
                        {
                            ProductId = product.ProductId,
                            PricePerUnit = product.Price,
                            Quantity = cartItem.Quantity
                        };
                        orderProducts.Add(orderProduct);
                    }

                    // create order
                    var order = new Order
                    {
                        CustomerId = customerId,
                        TotalPrice = totalPrice,
                        Status = 0,
                        OrderDate = DateTime.Now,
                        ExpiredDate = DateTime.Now.AddDays(1),
                    };
                    await _unitOfWork.OrderRepository.InsertAsync(order);
                    await _unitOfWork.SaveAsync();

                    // create order detail
                    foreach (var orderProduct in orderProducts)
                    {
                        var orderDetail = new OrderDetail
                        {
                            OrderId = order.OrderId,
                            ProductId = orderProduct.ProductId,
                            PricePerUnit = orderProduct.PricePerUnit,
                            Quantity = orderProduct.Quantity
                        };
                        await _unitOfWork.OrderDetailRepository.InsertAsync(orderDetail);
                        await _unitOfWork.SaveAsync();
                    }

                    // minus quantity of product
                    foreach (var orderProduct in orderProducts)
                    {
                        var product = await _unitOfWork.ProductRepository.GetByIDAsync(orderProduct.ProductId);
                        if (product.Quantity < orderProduct.Quantity)
                        {
                            throw new Exception("Not enough product in stock");
                        }
                        product.Quantity = product.Quantity - orderProduct.Quantity;
                        await _unitOfWork.ProductRepository.UpdateAsync(product);
                        await _unitOfWork.SaveAsync();
                    }

                    // delete items in cart
                    foreach (var cartItem in cartItems)
                    {
                        var item = await _unitOfWork.CartItemRepository.GetByIDAsync(cartItem.ItemId);
                        await _unitOfWork.CartItemRepository.DeleteAsync(item);
                        await _unitOfWork.SaveAsync();
                    }
                    var paymentUrl = CreateVnpayLink(order);
                    await transaction.CommitAsync();
                    return paymentUrl;
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                    throw new Exception(ex.Message);
                }
            }
        }*/

        /*private string CreateVnpayLink(Order order)
        {
            var paymentUrl = string.Empty;

            var vpnRequest = new VNPayRequest(_configuration["VNpay:Version"], _configuration["VNpay:tmnCode"],
                order.CreatedAt, "10.87.13.209", (decimal)order.TotalPrice, "VND", "other",
                $"Thanh toan don hang {order.OrderId}", _configuration["VNpay:ReturnUrl"],
                $"{order.OrderId}", order.ExpiredDate);

            paymentUrl = vpnRequest.GetLink(_configuration["VNpay:PaymentUrl"],
                _configuration["VNpay:HashSecret"]);

            return paymentUrl;
        }*/

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
