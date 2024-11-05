using Microsoft.AspNetCore.Mvc;
using PulpTicket.Application.Interfaces;
using PulpTicket.Application.DTOs;
using AutoMapper;


namespace PulpTicket.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookingController : ControllerBase // Fixed the class name
    {
        private readonly IBookingServices _bookingServices;
        private readonly IMapper _mapper;

        public BookingController(IBookingServices bookingService, IMapper mapper) // Fixed constructor
        {
            _bookingServices = bookingService;
            _mapper = mapper;
        }

        [HttpGet("{bookingId}")]
        public async Task<IActionResult> GetBooking(Guid bookingId)
        {
            var bookingDto = await _bookingServices.GetBookingByIdAsync(bookingId);
            if (bookingDto == null)
                return NotFound();

            return Ok(bookingDto);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBookings()
        {
            var bookingDtos = await _bookingServices.GetAllBookingsAsync();
            return Ok(bookingDtos);
        }

        [HttpPost]
        public async Task<IActionResult> CreateBooking([FromBody] BookingDtos bookingDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var createdBooking = await _bookingServices.CreateBookingAsync(bookingDto);
            return CreatedAtAction(nameof(GetBooking), new { bookingId = createdBooking.Booking_Id }, createdBooking);
        }

        [HttpPut("{bookingId}")]
        public async Task<IActionResult> UpdateBooking(Guid bookingId, [FromBody] BookingDtos bookingDto)
        {
            if (bookingId != bookingDto.Booking_Id)
                return BadRequest("ID mismatch");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _bookingServices.UpdateBookingAsync(bookingDto);
            return NoContent();
        }

        [HttpDelete("{bookingId}")]
        public async Task<IActionResult> DeleteBooking(Guid bookingId)
        {
            await _bookingServices.DeleteBookingAsync(bookingId);
            return Ok("Deleted");
        }
    }
}
