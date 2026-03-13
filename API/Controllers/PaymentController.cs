using Application.UseCases.Payment.Create;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly CreatePaymentUseCase _createPaymentUseCase;

        public PaymentController(CreatePaymentUseCase createPaymentUseCase)
        {
            _createPaymentUseCase = createPaymentUseCase;
        }

        [HttpPost("CreatePayment")]
        public async Task<ActionResult<PaymentCreateRequestDTO>> CreatePayment(
        [FromBody] PaymentCreateRequestDTO dto)
        {
            var result = await _createPaymentUseCase.ExecuteAsync(dto);

            return Ok(result);
        }
    }
}
