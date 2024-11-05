using Microsoft.AspNetCore.Mvc;
using PulpTicket.Application.Interfaces;
using PulpTicket.Application.DTOs;
using AutoMapper;

using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Authorization;

namespace PulpTicket.API.Controllers
{
    [EnableCors("AllowFrontendOrigin")]
    [ApiController]
    [Route("api/[controller]")]
   
    public class UsersController : ControllerBase
    {
        private readonly IUserServices _userService;
        private readonly IMapper _mapper;

        public UsersController(IUserServices userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(Guid id)
        {
            var userDto = await _userService.GetUserByIdAsync(id);
            if (userDto == null)
                return NotFound();

            return Ok(userDto);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUser()
        {
            var userDtos = await _userService.GetAllUsersAsync();
            return Ok(userDtos);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] UserDtos userDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var createdUser = await _userService.CreateUserAsync(userDto);
            return CreatedAtAction(nameof(GetUser), new { id = createdUser.Id }, createdUser);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(Guid id, [FromBody] UserDtos userDto)
        {
            if (id != userDto.Id)
                return BadRequest("ID mismatch");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _userService.UpdateUserAsync(userDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(Guid id)
        {
            await _userService.DeleteUserAsync(id);
            return NoContent();
        }
    }
}
