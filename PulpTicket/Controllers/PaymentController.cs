// File: PulpTicket.API/Controllers/PaymentsController.cs
using Microsoft.AspNetCore.Mvc;
using PulpTicket.Application.Interfaces;
using PulpTicket.Application.DTOs;
using AutoMapper;


namespace PulpTicket.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PaymentsController : ControllerBase
    {
        private readonly IPaymentServices _paymentService;
        private readonly IMapper _mapper;

        public PaymentsController(IPaymentServices paymentService, IMapper mapper)
        {
            _paymentService = paymentService;
            _mapper = mapper;
        }

        [HttpGet("{paymentId}")]
        public async Task<IActionResult> GetPayment(Guid paymentId)
        {
            var paymentDto = await _paymentService.GetPaymentByIdAsync(paymentId);
            if (paymentDto == null)
                return NotFound();

            return Ok(paymentDto);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPayments()
        {
            var paymentDtos = await _paymentService.GetAllPaymentsAsync();
            return Ok(paymentDtos);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePayment([FromBody] PaymentDtos paymentDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var createdPayment = await _paymentService.CreatePaymentAsync(paymentDto);
            return CreatedAtAction(nameof(GetPayment), new { paymentId = createdPayment.PaymentID }, createdPayment);
        }

        [HttpPut("{paymentId}")]
        public async Task<IActionResult> UpdatePayment(Guid paymentId, [FromBody] PaymentDtos paymentDto)
        {
            if (paymentId != paymentDto.PaymentID)
                return BadRequest("ID mismatch");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _paymentService.UpdatePaymentAsync(paymentDto);
            return NoContent();
        }

        [HttpDelete("{paymentId}")]
        public async Task<IActionResult> DeletePayment(Guid paymentId)
        {
            await _paymentService.DeletePaymentAsync(paymentId);
            return Ok("Deleted");
        }
    }
}

