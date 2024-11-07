using KoiDeliv.Service.DTO.Create;
using KoiDeliv.Service.DTO.Update;
using KoiDeliv.Service.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KoiDeliverySever.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RouteController : ControllerBase
    {
        private readonly IRouteService _RouteService;

        public RouteController(IRouteService RouteService)
        {
            _RouteService = RouteService ?? throw new ArgumentNullException(nameof(RouteService));
        }

        // GET: api/Route/Routes
        [HttpGet("Routes")]
        public async Task<IActionResult> GetAllRoutes()
        {
            try
            {
                var result = await _RouteService.GetAll();
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

        // GET: api/Route/{id}
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetRouteById(int id)
        {
            try
            {
                var result = await _RouteService.GetById(id);
                if (result.Success)
                {
                    return Ok(result.Data);
                }
                return NotFound(new { message = "Route not found" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = ex.Message });
            }
        }

        // POST: api/Route
        [HttpPost]
        public async Task<IActionResult> CreateRoute([FromBody] CreateRouteDTO createRouteDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var result = await _RouteService.CreateRoute(createRouteDto);
                if (result.Success)
                {
                    return Ok(new { message = "Route created successfully", data = result.Data });
                }
                return BadRequest(new { message = result.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = ex.Message });
            }
        }

        // PUT: api/Route/{id}
        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateRoute(int id, [FromBody] UpdateRouteDTO updateRouteDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                updateRouteDto.RoutedId = id; // Assign the ID from the route

                var result = await _RouteService.Update(updateRouteDto);

                if (result.Success)
                    return Ok(new { message = "Route updated successfully", data = result.Data });

                return BadRequest(new { message = result.Message });
            }
            catch (Exception ex)
            {
                // Log the exception (consider using a logging framework)
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = ex.Message });
            }
        }

        // DELETE: api/Route/{id}
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteRoute(int id)
        {
            try
            {
                var result = await _RouteService.DeleteById(id);
                if (result.Success)
                    return Ok(new { message = "Route deleted successfully" });

                return BadRequest(new { message = result.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = ex.Message });
            }
        }
    }
}
