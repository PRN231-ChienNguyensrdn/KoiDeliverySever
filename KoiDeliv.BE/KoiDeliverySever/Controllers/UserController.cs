using KoiDeliv.Service.DTO.Create;
using KoiDeliv.Service.DTO.Update;
using KoiDeliv.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace KoiDeliverySever.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class UserController : ControllerBase
	{
		private readonly IUserService _userService;

		public UserController(IUserService userService)
		{
			_userService = userService ?? throw new ArgumentNullException(nameof(userService));
		}

		// GET: api/User
		[HttpGet("Users")]
		public async Task<IActionResult> GetAllUsers()
		{
			try
			{
				var users = await _userService.GetAll();
				return Ok(users);
			}
			catch (Exception ex)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, new { message = ex.Message });
			}
		}

		// GET: api/User/{id}
		[HttpGet("{id:int}")]
		public async Task<IActionResult> GetUserById(int id)
		{
			try
			{
				var user = await _userService.GetById(id);
				if (user == null)
					return NotFound(new { message = "User not found" });

				return Ok(user);
			}
			catch (Exception ex)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, new { message = ex.Message });
			}
		}

		// POST: api/User
		[HttpPost]
		public async Task<IActionResult> CreateUser([FromBody] CreateUserDTO createUserDto)
		{
			if (!ModelState.IsValid)
				return BadRequest(ModelState);
			try
			{
				string hasdedPass = _userService.HashAndTruncatePassword(createUserDto.PasswordHash);
				createUserDto.PasswordHash = hasdedPass;
				var result = await _userService.Save(createUserDto);
				if (result.Success)
				{
					return Ok(new { message = "User created successfully", data = result.Data });
				}
				return BadRequest(new { message = result.Message });
			}
			catch (Exception ex)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, new { message = ex.Message });
			}
		}

		// PUT: api/User/{id}
		[HttpPut("{id:int}")]
		public async Task<IActionResult> UpdateUser(int id, [FromBody] UpdateUserDTO updateUserDto)
		{
			if (!ModelState.IsValid)
				return BadRequest(ModelState);

			try
			{
				updateUserDto.UserId = id; // Assign the correct ID from the route
				var result = await _userService.Update(updateUserDto);

				if (result.Success)
					return Ok(new { message = "User updated successfully", data = result.Data.ToString() });

				return BadRequest(new { message = result.Message });
			}
			catch (Exception ex)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, new { message = ex.Message });
			}
		}

		// DELETE: api/User/{id}
		[HttpDelete("{id:int}")]
		public async Task<IActionResult> DeleteUser(int id)
		{
			try
			{
				var result = await _userService.DeleteById(id);
				if (result.Success)
					return Ok(new { message = "User deleted successfully" });

				return BadRequest(new { message = result.Message });
			}
			catch (Exception ex)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, new { message = ex.Message });
			}
		}
	}
}
