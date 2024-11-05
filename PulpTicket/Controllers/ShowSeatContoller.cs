using Microsoft.AspNetCore.Mvc;
using PulpTicket.Application.Interfaces;
using PulpTicket.Application.DTOs;
using AutoMapper;


namespace PulpTicket.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ShowSeatsController : ControllerBase
    {
        private readonly IShowSeatServices _showSeatServices;
        private readonly IMapper _mapper;

        public ShowSeatsController(IShowSeatServices showSeatServices, IMapper mapper)
        {
            _showSeatServices = showSeatServices;
            _mapper = mapper;
        }

        [HttpGet("{showSeatId}")]
        public async Task<IActionResult> GetShowSeat(Guid showSeatId)
        {
            var showSeatDto = await _showSeatServices.GetShowSeatByIdAsync(showSeatId);
            if (showSeatDto == null)
                return NotFound();

            return Ok(showSeatDto);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllShowSeats()
        {
            var showSeatDtos = await _showSeatServices.GetAllShowSeatsAsync();
            return Ok(showSeatDtos);
        }

        [HttpPost]
        public async Task<IActionResult> CreateShowSeat([FromBody] ShowSeatDtos showSeatDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var createdShowSeat = await _showSeatServices.CreateShowSeatAsync(showSeatDto);
            return CreatedAtAction(nameof(GetShowSeat), new { showSeatId = createdShowSeat.ShowSeatId }, createdShowSeat);
        }


        [HttpPut("{showSeatId}")]
        public async Task<IActionResult> UpdateShowSeat(Guid showSeatId, [FromBody] ShowSeatDtos showSeatDto)
        {
            if (showSeatId != showSeatDto.ShowSeatId)
                return BadRequest("ID mismatch");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _showSeatServices.UpdateShowSeatAsync(showSeatDto);
            return NoContent();
        }

        [HttpDelete("{showSeatId}")]
        public async Task<IActionResult> DeleteShowSeat(Guid showSeatId)
        {
            await _showSeatServices.DeleteShowSeatAsync(showSeatId);
            return Ok("Deleted");
        }
    }
}
