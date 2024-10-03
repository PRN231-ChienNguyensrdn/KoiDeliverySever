using KoiDeliv.Service.DTO.Create;
using KoiDeliv.Service.DTO.Update;
using KoiDeliv.Service.Implementations;
using KoiDeliv.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace KoiDeliverySever.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class PriceController : ControllerBase
	{
		private readonly IPriceService _priceService;

		public PriceController(IPriceService priceService)
		{
			_priceService = priceService ?? throw new ArgumentNullException(nameof(priceService));
		}

		// GET: api/Price/GetAllPrices
		[HttpGet("GetAllPrices")]
		public async Task<IActionResult> GetAllPrice()
		{
			try
			{
				var prices = await _priceService.GetAll();
				return Ok(prices);
			}
			catch (Exception ex)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, new { message = ex.Message });
			}
		}

		// GET: api/Price/{id}
		[HttpGet("{id:int}")]
		public async Task<IActionResult> GetPriceById(int id)
		{
			try
			{
				var price = await _priceService.GetById(id);
				if (price == null)
					return NotFound(new { message = "Price not found" });

				return Ok(price);
			}
			catch (Exception ex)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, new { message = ex.Message });
			}
		}

		// POST: api/Price
		[HttpPost]
		public async Task<IActionResult> CreatePrice([FromBody] CreatePriceListDTO createPriceDto)
		{
			if (!ModelState.IsValid)
				return BadRequest(ModelState);

			try
			{
				var result = await _priceService.Save(createPriceDto);
				if (result.Success)
				{
					return Ok(new { message = "Price created successfully", data = result.Data });
				}
				return BadRequest(new { message = result.Message });
			}
			catch (Exception ex)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, new { message = ex.Message });
			}
		}

		// PUT: api/Price/{id}
		[HttpPut("{id:int}")]
		public async Task<IActionResult> UpdatePrice(int id, [FromBody] UpdatePriceListDTO updatePriceDto)
		{
			if (!ModelState.IsValid)
				return BadRequest(ModelState);

			try
			{
				updatePriceDto.PriceListId = id; // Assign the correct ID from the route
				var result = await _priceService.Update(updatePriceDto);

				if (result.Success)
					return Ok(new { message = "Price updated successfully", data = result.Data });

				return BadRequest(new { message = result.Message });
			}
			catch (Exception ex)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, new { message = ex.Message });
			}
		}

		// DELETE: api/Price/{id}
		[HttpDelete("{id:int}")]
		public async Task<IActionResult> DeletePrice(int id)
		{
			try
			{
				var result = await _priceService.DeleteById(id);
				if (result.Success)
					return Ok(new { message = "Price deleted successfully" });

				return BadRequest(new { message = result.Message });
			}
			catch (Exception ex)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, new { message = ex.Message });
			}
		}
	}
}
