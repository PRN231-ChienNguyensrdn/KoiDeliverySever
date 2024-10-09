using KoiDeliv.DataAccess.Repository;
using KoiDeliv.Service.DTO.Create;
using KoiDeliv.Service.DTO.Update;
using KoiDeliv.Service.Implementations;
using KoiDeliv.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace KoiDeliverySever.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class FeedbackController : ControllerBase
	{
		private readonly IFeedbackService _feedbackService;
	 

		public FeedbackController(IFeedbackService feedbackService)
		{
			_feedbackService = feedbackService ;
		}

		// GET: api/Feedback/Feedbacks
		[HttpGet("Feedbacks")]
		public async Task<IActionResult> GetAllFeedbacks()
		{
			try
			{
				var feedbacks = await _feedbackService.GetAll();
			 
				return Ok( feedbacks);
			}
			catch (Exception ex)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, new { message = ex.Message });
			}
		}

		// GET: api/Feedback/{id}
		[HttpGet("{id:int}")]
		public async Task<IActionResult> GetFeedbackById(int id)
		{
			try
			{
				var feedback = await _feedbackService.GetById(id);
				if (feedback == null)
					return NotFound(new { message = "Feedback not found" });

				return Ok(feedback);
			}
			catch (Exception ex)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, new { message = ex.Message });
			}
		}

		// POST: api/Feedback
		[HttpPost]
		public async Task<IActionResult> CreateFeedback([FromBody] CreateRatingsFeedbackDTO createFeedbackDto)
		{
			if (!ModelState.IsValid)
				return BadRequest(ModelState);

			try
			{
				var result = await _feedbackService.Save(createFeedbackDto);
				if (result.Success)
				{
					return Ok(new { message = "Feedback created successfully", data = result.Data });
				}
				return BadRequest(new { message = result.Message });
			}
			catch (Exception ex)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, new { message = ex.Message });
			}

			//if(createFeedbackDto == null)
			//{
			//	return BadRequest("Feedback data is required");
			//}
			//var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
			//if (userIdClaim == null || !int.TryParse(userIdClaim.Value, out int feebackerId))
			//{
			//	return Unauthorized("User ID is not available. ");

			//}
			//var result = await _feedbackService.Save(createFeedbackDto, feebackerId);
			//if (result.Success)
			//{
			//	return Ok(result);


			//}
			//return StatusCode(StatusCodes.Status500InternalServerError, result);
		}

		// PUT: api/Feedback/{id}
		[HttpPut("{id:int}")]
		public async Task<IActionResult> UpdateFeedback(int id, [FromBody] UpdateRatingsFeedbackDTO updateFeedbackDto)
		{
			if (!ModelState.IsValid)
				return BadRequest(ModelState);

			try
			{
				updateFeedbackDto.FeedbackId = id; // Assign the correct ID from the route
				var result = await _feedbackService.Update(updateFeedbackDto);

				if (result.Success)
					return Ok(new { message = "Feedback updated successfully", data = result.Data });

				return BadRequest(new { message = result.Message });
			}
			catch (Exception ex)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, new { message = ex.Message });
			}
		}

		// DELETE: api/Feedback/{id}
		[HttpDelete("{id:int}")]
		public async Task<IActionResult> DeleteFeedback(int id)
		{
			try
			{
				var result = await _feedbackService.DeleteById(id);
				if (result.Success)
					return Ok(new { message = "Feedback deleted successfully" });

				return BadRequest(new { message = result.Message });
			}
			catch (Exception ex)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, new { message = ex.Message });
			}
		}
	}
}
