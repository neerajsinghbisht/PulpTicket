using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Pulpticket.Application.DTOs;
using PulpTicket.Application.Interfaces;

namespace PUlpTicket.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserServices _userService;

        public UsersController(IUserServices userService)
        {
            _userService = userService;
        }

        // GET: api/Users
        [HttpGet]
        public async Task<IActionResult> GetAll(int pageNumber = 1, int pageSize = 10)
        {
            try
            {
                if (pageNumber <= 0 || pageSize <= 0)
                {
                    return BadRequest("Invalid page number or page size.");
                }

                var users = await _userService.GetAllUsersAsync(pageNumber, pageSize);
                return Ok(users);
            }
            catch (Exception ex)
            {
                // Log the exception details
                return StatusCode(500, "Internal server error");
            }
        }

        // GET: api/Users/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            try
            {
                var user = await _userService.GetUserByIdAsync(id);
                if (user == null)
                {
                    return NotFound();
                }
                return Ok(user);
            }
            catch (Exception ex)
            {
                // Log the exception details
                return StatusCode(500, "Internal server error");
            }
        }

        // POST: api/Users
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] User userDto)
        {
            try
            {
                if (userDto == null)
                {
                    return BadRequest("User data is null.");
                }

                await _userService.AddUserAsync(userDto);
                return CreatedAtAction(nameof(GetById), new { id = userDto.Id }, userDto);
            }
            catch (Exception ex)
            {
                // Log the exception details
                return StatusCode(500, "Internal server error");
            }
        }

        // PUT: api/Users/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UserDto userDto)
        {
            try
            {
                if (userDto == null || id != userDto.Id)
                {
                    return BadRequest("User data is invalid.");
                }

                await _userService.UpdateUserAsync(userDto);
                return NoContent();
            }
            catch (Exception ex)
            {
                // Log the exception details
                return StatusCode(500, "Internal server error");
            }
        }

        // DELETE: api/Users/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                await _userService.DeleteUserAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                // Log the exception details
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
