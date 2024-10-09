using KoiDeliv.Service.DTO.Create;
using KoiDeliv.Service.DTO.Update;
using KoiDeliv.Service.Interface;
using Microsoft.AspNetCore.Mvc;


namespace KoiDeliverySever.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ShipmentController : ControllerBase
	{
		private readonly IShipmentService _shipmentService;

		public ShipmentController(IShipmentService shipmentService)
		{
			_shipmentService = shipmentService ?? throw new ArgumentNullException(nameof(shipmentService));
		}

		// GET: api/Shipment
		[HttpGet("Shipments")]
		public async Task<IActionResult> GetAllShipments()
		{
			try
			{
				var shipments = await _shipmentService.GetAll();
				return Ok(shipments);
			}
			catch (Exception ex)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, new { message = ex.Message });
			}
		}

		// GET: api/Shipment/{id}
		[HttpGet("{id:int}")]
		public async Task<IActionResult> GetShipmentById(int id)
		{
			try
			{
				var shipment = await _shipmentService.GetById(id);
				if (shipment == null)
					return NotFound(new { message = "Shipment not found" });

				return Ok(shipment);
			}
			catch (Exception ex)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, new { message = ex.Message });
			}
		}

		// POST: api/Shipment
		[HttpPost]
		public async Task<IActionResult> CreateShipment([FromBody] CreateShipmentDTO createShipmentDto)
		{
			if (!ModelState.IsValid)
				return BadRequest(ModelState);

			try
			{
				var result = await _shipmentService.Save(createShipmentDto);
				if (result.Success)
				{
					return Ok(new { message = "Shipment created successfully", data = result.Data });
				}
				return BadRequest(new { message = result.Message });
			}
			catch (Exception ex)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, new { message = ex.Message });
			}
		}

		// PUT: api/Shipment/{id}
		[HttpPut("{id:int}")]
		public async Task<IActionResult> UpdateShipment(int id, [FromBody] UpdateShipmentDTO updateShipmentDto)
		{
			// Check if updateShipmentDto is null
			if (updateShipmentDto == null)
			{
				return BadRequest(new { message = "Shipment data cannot be null" });
			}

			// Validate the model state
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			try
			{
				// Ensure that the Shipment ID is correctly assigned
				updateShipmentDto.ShipmentId = id;

				var result = await _shipmentService.Update(updateShipmentDto);

				if (result.Success)
				{
					return Ok(new { message = "Shipment updated successfully", data = result.Data });
				}

				return BadRequest(new { message = result.Message });
			}
			catch (Exception ex)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, new { message = ex.Message });
			}
		}



		// DELETE: api/Shipment/{id}
		[HttpDelete("{id:int}")]
		public async Task<IActionResult> DeleteShipment(int id)
		{
			try
			{
				var result = await _shipmentService.DeleteById(id);
				if (result.Success)
					return Ok(new { message = "Shipment deleted successfully" });

				return BadRequest(new { message = result.Message });
			}
			catch (Exception ex)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, new { message = ex.Message });
			}
		}
	}
}
