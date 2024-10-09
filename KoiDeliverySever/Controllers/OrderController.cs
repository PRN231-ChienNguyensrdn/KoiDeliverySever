using KoiDeliv.Service.DTO.Create;
using KoiDeliv.Service.DTO.Update;
using KoiDeliv.Service.Implementations;
using KoiDeliv.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace KoiDeliverySever.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class OrderController : ControllerBase
	{
		private readonly IOrderService _orderService;

		public OrderController(IOrderService orderService)
		{
			_orderService = orderService ?? throw new ArgumentNullException(nameof(orderService));
		}

		// GET: api/Order/Orders
		[HttpGet("Orders")]
		public async Task<IActionResult> GetAllOrders()
		{
			try
			{
				var orders = await _orderService.GetAll();
				return Ok(orders);
			}
			catch (Exception ex)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, new { message = ex.Message });
			}
		}

		// GET: api/Order/{id}
		[HttpGet("{id:int}")]
		public async Task<IActionResult> GetOrderById(int id)
		{
			try
			{
				var order = await _orderService.GetById(id);
				if (order == null)
					return NotFound(new { message = "Order not found" });

				return Ok(order);
			}
			catch (Exception ex)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, new { message = ex.Message });
			}
		}

		// POST: api/Order
		[HttpPost]
		public async Task<IActionResult> CreateOrder([FromBody] CreateOrderDTO createOrderDto)
		{
			if (!ModelState.IsValid)
				return BadRequest(ModelState);

			try
			{
				var result = await _orderService.Save(createOrderDto);
				if (result.Success)
				{
					return Ok(new { message = "Order created successfully", data = result.Data });
				}
				return BadRequest(new { message = result.Message });
			}
			catch (Exception ex)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, new { message = ex.Message });
			}
		}

		// PUT: api/Order/{id}
		[HttpPut("{id:int}")]
		public async Task<IActionResult> UpdateOrder(int id, [FromBody] UpdateOrderDTO updateOrderDto)
		{
			if (!ModelState.IsValid)
				return BadRequest(ModelState);

			try
			{
				updateOrderDto.OrderId = id; // Assign the correct ID from the route
				var result = await _orderService.Update(updateOrderDto);

				if (result.Success)
					return Ok(new { message = "Order updated successfully", data = result.Data });

				return BadRequest(new { message = result.Message });
			}
			catch (Exception ex)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, new { message = ex.Message });
			}
		}

		// DELETE: api/Order/{id}
		[HttpDelete("{id:int}")]
		public async Task<IActionResult> DeleteOrder(int id)
		{
			try
			{
				var result = await _orderService.DeleteById(id);
				if (result.Success)
					return Ok(new { message = "Order deleted successfully" });

				return BadRequest(new { message = result.Message });
			}
			catch (Exception ex)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, new { message = ex.Message });
			}
		}
	}
}
