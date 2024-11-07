using KoiDeliv.Service.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KoiDeliverySever.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GPSController : ControllerBase
    {
        private readonly IGPSService _gPSService;

        public GPSController(IGPSService gSPService)
        {
            _gPSService = gSPService;
        }

        [HttpPost]
        public async Task<IActionResult> ImportGSP(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return BadRequest("Please upload a valid CSV file.");
            }
            try
            {
                await _gPSService.ImportFile(file);
                return Ok("Import file is success!!!");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
