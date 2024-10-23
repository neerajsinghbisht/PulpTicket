using AutoMapper;
using PulpTicket.Application.DTOs;
using PulpTicket.Application.Interfaces;
using PulpTicket.Domain.Entities;
using PulpTicket.Domain.Repositories;

namespace PulpTicket.Application.Services
{
    public class AddressServices : IAddressServices
    {
        private readonly IAddressRepository _addressRepository;
        private readonly IMapper _mapper;

        public AddressServices(IAddressRepository addressRepository, IMapper mapper)
        {
            _addressRepository = addressRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<AddressDtos>> GetAllAsync()
        {
            var addresses = await _addressRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<AddressDtos>>(addresses);
        }

        public async Task<AddressDtos> CreateAddressAsync(AddressDtos addressDtos)
        {
            var address = _mapper.Map<Address>(addressDtos);
            await _addressRepository.AddAsync(address);
            return _mapper.Map<AddressDtos>(address);
        }

        public async Task<AddressDtos> GetAddressByIdAsync(Guid AddressId)
        {
            var address = await _addressRepository.GetByIdAsync(AddressId);
            return _mapper.Map<AddressDtos>(address);
        }

        public async Task UpdateAddressAsync(AddressDtos addressDtos)
        {
            var address = _mapper.Map<Address>(addressDtos);
            await _addressRepository.UpdateAsync(address);
        }

        public async Task DeleteAddressAsync(Guid AddressId)
        {
            await _addressRepository.DeleteAsync(AddressId);
        }
    }
}
