using Microsoft.AspNetCore.Mvc;
using PulpTicket.Application.Interfaces;
using PulpTicket.Application.DTOs;
using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace PulpTicket.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AddressesController : ControllerBase
    {
        private readonly IAddressServices _addressService;
        private readonly IMapper _mapper;

        public AddressesController(IAddressServices addressService, IMapper mapper)
        {
            _addressService = addressService;
            _mapper = mapper;
        }

        [HttpGet("{Address_id}")]
        public async Task<IActionResult> GetAddress(Guid Address_id)
        {
            var addressDto = await _addressService.GetAddressByIdAsync(Address_id);
            if (addressDto == null)
                return NotFound();

            return Ok(addressDto);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAddresses()
        {
            var addressDtos = await _addressService.GetAllAsync();
            return Ok(addressDtos);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAddress([FromBody] AddressDtos addressDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var createdAddress = await _addressService.CreateAddressAsync(addressDto);
            return CreatedAtAction(nameof(GetAddress), new { Address_id = createdAddress.Address_Id }, createdAddress);
        }

        [HttpPut("{Address_id}")]
        public async Task<IActionResult> UpdateAddress(Guid id, [FromBody] AddressDtos addressDto)
        {
            if (id != addressDto.Address_Id)
                return BadRequest("ID mismatch");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _addressService.UpdateAddressAsync(addressDto);
            return NoContent();
        }

        [HttpDelete("{Address_id}")]
        public async Task<IActionResult> DeleteAddress(Guid Address_id)
        {
            await _addressService.DeleteAddressAsync(Address_id);
            return Ok("deleted");
        }
    }
}
