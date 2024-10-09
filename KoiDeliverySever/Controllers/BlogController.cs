using KoiDeliv.Service.DTO.Create;
using KoiDeliv.Service.DTO.Update;
using KoiDeliv.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace KoiDeliverySever.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class BlogController : ControllerBase
	{
		private readonly IBlogService _blogService;

		public BlogController(IBlogService blogService)
		{
			_blogService = blogService ?? throw new ArgumentNullException(nameof(blogService));
		}

		// GET: api/Blog/Blogs
		[HttpGet("Blogs")]
		public async Task<IActionResult> GetAllBlogs()
		{
			try
			{
				var result = await _blogService.GetAll();
				if (result.Success)
				{
					return Ok(result.Data);
				}
				return NotFound(new { message = result.Message });
			}
			catch (Exception ex)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, new { message = ex.Message });
			}
		}

		// GET: api/Blog/{id}
		[HttpGet("{id:int}")]
		public async Task<IActionResult> GetBlogById(int id)
		{
			try
			{
				var result = await _blogService.GetById(id);
				if (result.Success)
				{
					return Ok(result.Data);
				}
				return NotFound(new { message = "Blog not found" });
			}
			catch (Exception ex)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, new { message = ex.Message });
			}
		}

		// POST: api/Blog
		[HttpPost]
		public async Task<IActionResult> CreateBlog([FromBody] CreateBlogDTO createBlogDto)
		{
			if (!ModelState.IsValid)
				return BadRequest(ModelState);

			try
			{
				var result = await _blogService.Save(createBlogDto);
				if (result.Success)
				{
					return Ok(new { message = "Blog created successfully", data = result.Data });
				}
				return BadRequest(new { message = result.Message });
			}
			catch (Exception ex)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, new { message = ex.Message });
			}
		}

		// PUT: api/Blog/{id}
		[HttpPut("{id:int}")]
		public async Task<IActionResult> UpdateBlog(int id, [FromBody] UpdateBlogDTO updateBlogDto)
		{
			if (!ModelState.IsValid)
				return BadRequest(ModelState);

			try
			{
				updateBlogDto.BlogId = id; // Assign the ID from the route

				var result = await _blogService.Update(updateBlogDto);

				if (result.Success)
					return Ok(new { message = "Blog updated successfully", data = result.Data });

				return BadRequest(new { message = result.Message });
			}
			catch (Exception ex)
			{
				// Log the exception (consider using a logging framework)
				return StatusCode(StatusCodes.Status500InternalServerError, new { message = ex.Message });
			}
		}

		// DELETE: api/Blog/{id}
		[HttpDelete("{id:int}")]
		public async Task<IActionResult> DeleteBlog(int id)
		{
			try
			{
				var result = await _blogService.DeleteById(id);
				if (result.Success)
					return Ok(new { message = "Blog deleted successfully" });

				return BadRequest(new { message = result.Message });
			}
			catch (Exception ex)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, new { message = ex.Message });
			}
		}
	}
}
