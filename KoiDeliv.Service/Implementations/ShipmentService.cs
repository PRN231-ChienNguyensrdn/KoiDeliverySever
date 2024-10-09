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

		public ShipmentService(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
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

				// If the order exists, proceed with creating the shipment
				var shipment = new Shipment
				{
					OrderId = shipDto.OrderID, // Make sure OrderId is set correctly
					SalesStaffId = shipDto.SalesStaffId,
					DeliveringStaffId = shipDto.DeliveringStaffId,
					HealthCheckStatus = shipDto.HealthCheckStatus,
					PackingStatus = shipDto.PackingStatus,
					ShippingStatus = shipDto.ShippingStatus,
					ForeignImportStatus = shipDto.ForeignImportStatus,
					CertificateIssued = shipDto.CertificateIssued,
					DeliveryDate = shipDto.DeliveryDate
				};

				// Create the shipment
				int result = await _unitOfWork.ShipmentRepo.CreateAsync(shipment);
				if (result > 0)
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


	}
}
