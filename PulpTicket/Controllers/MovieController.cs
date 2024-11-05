using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using PulpTicket.Application.Interfaces;
using PulpTicket.Application.DTOs;


namespace PulpTicket.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class MovieController : ControllerBase
    {
        private readonly IMovieService _moviService;
        private readonly IMapper _mapper;

        public MovieController(IMovieService movieService ,IMapper mapper)

        {
            _moviService = movieService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync([FromQuery] String? filterOn, [FromQuery] String? filterQuery, [FromQuery] string? sortBy = "Name",
    [FromQuery] bool isDescending = false,
            [FromQuery] int pageNumber=1,[FromQuery] int pagesize=1000)
        {
            var movieDtos = await _moviService.GetAllAsync(filterOn,filterQuery, sortBy, isDescending, pageNumber,pagesize);

            return Ok(movieDtos);
        }

        [HttpGet("{Movie_Id}")]

        public async Task<IActionResult> GetById(Guid Movie_Id)
            
        {
            var result = await _moviService.GetMovieByIdAsync(Movie_Id);
            if (result == null )
            {
                return NotFound();

            }
            return Ok(result);

        }
        [HttpPost]
        public async Task<IActionResult> CreateMovie([FromBody] MovieDtos movieDtos)
        {
            if (ModelState.IsValid)
            {
                var createdmovie = await _moviService.CreateMovieAsync(movieDtos);
                return CreatedAtAction(nameof(GetById), new { Movie_id = createdmovie.Movie_Id }, createdmovie);
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpDelete("{Movie_Id}")]
        public async Task<IActionResult> Delete(Guid Movie_Id)
        {
            await _moviService.DeleteMovieAsync(Movie_Id);
            return Ok("deleted");
        }

    }
}
