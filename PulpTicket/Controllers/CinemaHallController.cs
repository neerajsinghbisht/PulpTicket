using Microsoft.AspNetCore.Mvc;
using PulpTicket.Application.Interfaces;
using PulpTicket.Application.DTOs;
using AutoMapper;

namespace PulpTicket.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CinemaHallController : ControllerBase
    {
        private readonly ICinemaHallServices _cinemaHallService; // Updated to use ICinemaHallService
        private readonly IMapper _mapper;

        public CinemaHallController(ICinemaHallServices cinemaHallService, IMapper mapper)
        {
            _cinemaHallService = cinemaHallService;
            _mapper = mapper;
        }

        [HttpGet("{cinemaHallId}")]
        public async Task<IActionResult> GetCinemaHall(Guid cinemaHallId)
        {
            var cinemaHallDto = await _cinemaHallService.GetCinemaHallByIdAsync(cinemaHallId);
            if (cinemaHallDto == null)
                return NotFound();

            return Ok(cinemaHallDto);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCinemaHalls()
        {
            var cinemaHallDtos = await _cinemaHallService.GetAllCinemaHallsAsync();
            return Ok(cinemaHallDtos);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCinemaHall([FromBody] CinemaHallDtos cinemaHallDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var createdCinemaHall = await _cinemaHallService.CreateCinemaHallAsync(cinemaHallDto);
            return CreatedAtAction(nameof(GetCinemaHall), new { cinemaHallId = createdCinemaHall.CinemaHallId }, createdCinemaHall);
        }

        [HttpPut("{cinemaHallId}")]
        public async Task<IActionResult> UpdateCinemaHall(Guid cinemaHallId, [FromBody] CinemaHallDtos cinemaHallDto)
        {
            if (cinemaHallId != cinemaHallDto.CinemaHallId)
                return BadRequest("ID mismatch");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _cinemaHallService.UpdateCinemaHallAsync(cinemaHallDto);
            return NoContent();
        }

        [HttpDelete("{cinemaHallId}")]
        public async Task<IActionResult> DeleteCinemaHall(Guid cinemaHallId)
        {
            await _cinemaHallService.DeleteCinemaHallAsync(cinemaHallId);
            return Ok("deleted");
        }
    }
}
