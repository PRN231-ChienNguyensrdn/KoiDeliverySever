using Business.Base;
using Common;
using KoiDeliv.DataAccess.Models;
using KoiDeliv.Service.DTO.Create;
using KoiDeliv.Service.DTO.Update;
using KoiDeliv.Service.Interface;
using Repository;
 
namespace KoiDeliv.Service.Implementations
{
	public class ShipmentService : IShipmentService
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IRouteService _routeService;
		public ShipmentService(IUnitOfWork unitOfWork, IRouteService routeService)
		{
			_unitOfWork = unitOfWork;
			_routeService = routeService;
		}

		public async Task<IBusinessResult> DeleteById(int id)
		{
			try
			{
				var shipment = await _unitOfWork.ShipmentRepo.GetByIdAsync(id);
				if (shipment != null)
				{
					bool result = await _unitOfWork.ShipmentRepo.RemoveAsync(shipment);
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
				var shipments = await _unitOfWork.ShipmentRepo.GetAllAsync();

				if (shipments == null || !shipments.Any())
				{
					return new BusinessResult(Const.WARNING_NO_DATA_CODE, Const.WARNING_NO_DATA_MSG);
				}

				return new BusinessResult(Const.SUCCESS_READ_CODE, Const.SUCCESS_READ_MSG, shipments);
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
				var shipment = await _unitOfWork.ShipmentRepo.GetByIdAsync(id);

				if (shipment == null)
				{
					return new BusinessResult(Const.WARNING_NO_DATA_CODE, Const.WARNING_NO_DATA_MSG);
				}

				return new BusinessResult(Const.SUCCESS_READ_CODE, Const.SUCCESS_READ_MSG, shipment);
			}
			catch (Exception ex)
			{
				return new BusinessResult(Const.ERROR_EXCEPTION, ex.Message);
			}
		}

        public async Task<IBusinessResult> GetShipmentsByDeliId(int deliId)
        {
            try
            {
                var shipments = await _unitOfWork.ShipmentRepo.GetShipmentsByDeliId(deliId);

                if (shipments == null || !shipments.Any())
                {
                    return new BusinessResult(Const.WARNING_NO_DATA_CODE, Const.WARNING_NO_DATA_MSG);
                }

                return new BusinessResult(Const.SUCCESS_READ_CODE, Const.SUCCESS_READ_MSG, shipments);
            }
            catch (Exception ex)
            {
                return new BusinessResult(Const.ERROR_EXCEPTION, ex.Message);
            }
        }

        public async Task<IBusinessResult> GetShipmentsByOrderId(int orderId)
        {
            try
            {
				var shipments = await _unitOfWork.ShipmentRepo.GetShipmentsByOrderId(orderId);

                if (shipments == null || !shipments.Any())
                {
                    return new BusinessResult(Const.WARNING_NO_DATA_CODE, Const.WARNING_NO_DATA_MSG);
                }

                return new BusinessResult(Const.SUCCESS_READ_CODE, Const.SUCCESS_READ_MSG, shipments);
            }
            catch (Exception ex)
            {
                return new BusinessResult(Const.ERROR_EXCEPTION, ex.Message);
            }
        }

        public async Task<IBusinessResult> GetShipmentsBySalesId(int salesId)
        {
            try
            {
				var shipments = await _unitOfWork.ShipmentRepo.GetShipmentsBySalesId(salesId);

                if (shipments == null || !shipments.Any())
                {
                    return new BusinessResult(Const.WARNING_NO_DATA_CODE, Const.WARNING_NO_DATA_MSG);
                }

                return new BusinessResult(Const.SUCCESS_READ_CODE, Const.SUCCESS_READ_MSG, shipments);
            }
            catch (Exception ex)
            {
                return new BusinessResult(Const.ERROR_EXCEPTION, ex.Message);
            }
        }

        public async Task<IBusinessResult> Save(CreateShipmentDTO shipDto)
		{
			try
			{
				// Check if the OrderID exists in the Orders table before creating the shipment
				var order = await _unitOfWork.OrderRepo.GetByIdAsync(shipDto.OrderID);
				if (order == null)
				{
					// Return an error if the OrderID doesn't exist
					return new BusinessResult(Const.FAIL_CREATE_CODE, "Order not found for the provided OrderID");
				}
                var shipment = new Shipment
                {
                    OrderId = shipDto.OrderID, // Make sure OrderId is set correctly
                    SalesStaffId = shipDto.SalesStaffId,
                    DeliveringStaffId = shipDto.DeliveringStaffId,
                    HealthCheckStatus = null,
                    PackingStatus = null,
                    ShippingStatus = null,
                    ForeignImportStatus = null,
                    CertificateIssued = shipDto.CertificateIssued,
                    DeliveryDate = order.DateShip,
                };
                int result = await _unitOfWork.ShipmentRepo.CreateAsync(shipment);

				var resultAddRoute = await HandleShipment(shipment.ShipmentId);
				if (result > 0 && resultAddRoute.Success)
				{
					return new BusinessResult(Const.SUCCESS_CREATE_CODE, Const.SUCCESS_CREATE_MSG);
				}

				return new BusinessResult(Const.FAIL_CREATE_CODE, Const.FAIL_CREATE_MSG);
			}
			catch (Exception ex)
			{
				// Catch and return any exceptions
				return new BusinessResult(Const.ERROR_EXCEPTION, ex.ToString());
			}
		}

        public async Task<IBusinessResult> HandleShipment(int shipmentId)
        {
			try
			{
				Shipment handleShipment = _unitOfWork.ShipmentRepo.GetById(shipmentId);
				var order = await _unitOfWork.OrderRepo.GetByIdAsync(handleShipment.OrderId);
				if (order == null)
				{
					return new BusinessResult(Const.FAIL_CREATE_CODE, "Order not found for the provided OrderID");
				}
				if (order.ShippingMethod == "Road")
				{
					CreateRouteDTO route1 = new CreateRouteDTO()
					{
						ShipmentId = handleShipment.ShipmentId,
						Status = false,
						Notice = "Lấy hàng",
						DateSetting = DateTime.Now,
						DateUpdate = null,
						Origin = "phường 25 quận bình thạnh",
						Adress = order.Origin,
					};
					await _routeService.CreateRoute(route1);
					CreateRouteDTO route2 = new CreateRouteDTO()
					{
						ShipmentId = handleShipment.ShipmentId,
						Status = false,
						Notice = "Giao hang",
						DateSetting = DateTime.Now,
						DateUpdate = null,
						Origin = order.Origin,
						Adress = order.Destination,
					};
					await _routeService.CreateRoute(route2);
				}
				else
				{
                    CreateRouteDTO route1 = new CreateRouteDTO()
                    {
                        ShipmentId = handleShipment.ShipmentId,
                        Status = false,
                        Notice = "Lấy hàng",
                        DateSetting = DateTime.Now,
                        DateUpdate = null,
                        Origin = "phường 25 quận bình thạnh",
                        Adress = order.Origin,
                    };
                    await _routeService.CreateRoute(route1);

                    CreateRouteDTO route2 = new CreateRouteDTO()
                    {
                        ShipmentId = handleShipment.ShipmentId,
                        Status = false,
                        Notice = "Điểm trung chuyển 1",
                        DateSetting = DateTime.Now,
                        DateUpdate = null,
                        Origin = order.Origin,
                        Adress = "phường 2 quận tân bình",
                    };
                    await _routeService.CreateRoute(route2);

                    CreateRouteDTO route3 = new CreateRouteDTO()
                    {
                        ShipmentId = handleShipment.ShipmentId,
                        Status = false,
                        Notice = "Điểm trung chuyển 2",
                        DateSetting = DateTime.Now,
                        DateUpdate = null,
                        Origin = "phường 2 quận tân bình",
                        Adress = "phường hiệp bình chánh quận thủ đức",
                    };
                    await _routeService.CreateRoute(route3);

                    CreateRouteDTO route4 = new CreateRouteDTO()
                    {
                        ShipmentId = handleShipment.ShipmentId,
                        Status = false,
                        Notice = "Hoàn tất giao hàng",
                        DateSetting = DateTime.Now,
                        DateUpdate = null,
                        Origin = "phường hiệp bình chánh quận thủ đức",
                        Adress = order.Destination,
                    };
                    await _routeService.CreateRoute(route4);
                }
                return new BusinessResult(Const.SUCCESS_CREATE_CODE, Const.SUCCESS_CREATE_MSG);
            }
            catch (Exception ex)
            {
                // Catch and return any exceptions
                return new BusinessResult(Const.ERROR_EXCEPTION, ex.ToString());
            }
        }

        public async Task<IBusinessResult> Update(UpdateShipmentDTO shipDto)
		{
			try
			{
				var existingShipment = await _unitOfWork.ShipmentRepo.GetByIdAsync(shipDto.ShipmentId);

				// Check if the shipment exists
				if (existingShipment == null)
				{
					return new BusinessResult(Const.FAIL_UPDATE_CODE, "Shipment not found");
				}

				// Update shipment details
				existingShipment.HealthCheckStatus = shipDto.HealthCheckStatus ?? existingShipment.HealthCheckStatus;
				existingShipment.PackingStatus = shipDto.PackingStatus ?? existingShipment.PackingStatus;
				existingShipment.ShippingStatus = shipDto.ShippingStatus ?? existingShipment.ShippingStatus;
				existingShipment.ForeignImportStatus = shipDto.ForeignImportStatus ?? existingShipment.ForeignImportStatus;

				int result = await _unitOfWork.ShipmentRepo.UpdateAsync(existingShipment);
               
                if (result > 0)
				{
					return new BusinessResult(Const.SUCCESS_UPDATE_CODE, Const.SUCCESS_UPDATE_MSG);
				}

				return new BusinessResult(Const.FAIL_UPDATE_CODE, Const.FAIL_UPDATE_MSG);
			}
			catch (Exception ex)
			{
				return new BusinessResult(Const.ERROR_EXCEPTION, ex.ToString());
			}
		}
        public async Task<IBusinessResult> UpdateOrderStatus(int orderId, string status)
        {
            try
            {
                var existOrder = await _unitOfWork.OrderRepo.GetByIdAsync(orderId);
                if (existOrder == null)
                {
                    return new BusinessResult(Const.FAIL_UPDATE_CODE, "Order not found");
                }

                existOrder.Status = status;

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
