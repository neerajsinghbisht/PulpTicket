using Microsoft.AspNetCore.Mvc;
using PulpTicket.Application.Interfaces;
using PulpTicket.Application.DTOs;
using AutoMapper;

namespace PulpTicket.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CityController : ControllerBase
    {
        private readonly ICityServices _cityService;
        private readonly IMapper _mapper;

        public CityController(ICityServices cityService, IMapper mapper)
        {
            _cityService = cityService;
            _mapper = mapper;
        }

        [HttpGet("{cityId}")]
        public async Task<IActionResult> GetCity(Guid cityId)
        {
            var cityDto = await _cityService.GetCityByIdAsync(cityId);
            if (cityDto == null)
                return NotFound();

            return Ok(cityDto);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCities()
        {
            var cityDtos = await _cityService.GetAllCitiesAsync();
            return Ok(cityDtos);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCity([FromBody] CityDtos cityDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var createdCity = await _cityService.CreateCityAsync(cityDto);
            return CreatedAtAction(nameof(GetCity), new { cityId = createdCity.CityId }, createdCity);
        }

        [HttpPut("{cityId}")]
        public async Task<IActionResult> UpdateCity(Guid cityId, [FromBody] CityDtos cityDtos)
        {
            if (cityId != cityDtos.CityId)
                return BadRequest("ID mismatch");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _cityService.UpdateCityAsync(cityDtos);
            return Ok();
        }

        [HttpDelete("{cityId}")]
        public async Task<IActionResult> DeleteCity(Guid cityId)
        {
            await _cityService.DeleteCityAsync(cityId);
            return Ok("Deleted");
        }
    }
}
