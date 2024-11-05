using Microsoft.AspNetCore.Mvc;
using PulpTicket.Application.Interfaces;
using PulpTicket.Application.DTOs;
using AutoMapper;

namespace PulpTicket.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    
        
        public class ShowsController : ControllerBase
        {
            private readonly IShowServices _showService; // Updated to use IShowService
            private readonly IMapper _mapper;

            public ShowsController(IShowServices showService, IMapper mapper)
            {
                _showService = showService;
                _mapper = mapper;
            }

            [HttpGet("{showId}")]
            public async Task<IActionResult> GetShow(Guid showId)
            {
                var showDto = await _showService.GetShowByIdAsync(showId);
                if (showDto == null)
                    return NotFound();

                return Ok(showDto);
            }

            [HttpGet]
            public async Task<IActionResult> GetAllShows()
            {
                var showDtos = await _showService.GetAllShowsAsync();
                return Ok(showDtos);
            }

            [HttpPost]
            public async Task<IActionResult> CreateShow([FromBody] ShowDtos showDto)
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var createdShow = await _showService.CreateShowAsync(showDto);
                return CreatedAtAction(nameof(GetShow), new { showId = createdShow.ShowId }, createdShow);
            }

            [HttpPut("{showId}")]
        public async Task<IActionResult> UpdateShow(Guid showId, [FromBody] ShowDtos showDto)
        {
            if (showId != showDto.ShowId)
                return BadRequest("ID mismatch");
           

            await _showService.UpdateShowAsync(showDto);
            return NoContent();
        }

        [HttpDelete("{showId}")]
            public async Task<IActionResult> DeleteShow(Guid showId)
            {
                await _showService.DeleteShowAsync(showId);
                return Ok("deleted");
            }
        }
    }

