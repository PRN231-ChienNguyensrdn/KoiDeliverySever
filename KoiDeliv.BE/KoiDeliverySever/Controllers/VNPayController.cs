using KoiDeliv.Service.DTO.Payment;
using KoiDeliv.Service.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KoiDeliverySever.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VNPayController : ControllerBase
    {
        private readonly ITransactionService _transactionService;

        public VNPayController(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }

        [HttpGet("vnpay-return")]
        public async Task<IActionResult> CreateVNPayPayment([FromQuery] PaymentRequest parameters)
        {
            try
            {
                string appScheme = "http://localhost:5001";

                if (parameters.vnp_BankTranNo == null)
                {
                    string redirectUrl = $"{appScheme}/payment-failed?";

                    return Redirect(redirectUrl);
                }
                var result = await _transactionService.CreatePayment(parameters);

                if (result != null)
                {
                    string redirectUrl = $"{appScheme}/payment-success?";

                    return Redirect(redirectUrl);
                }
                else
                {
                    return NotFound("Order does not created");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
