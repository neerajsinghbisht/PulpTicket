using PulpTicket.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PulpTicket.Application.Interfaces
{
    public interface IAddressServices
    {
        Task<IEnumerable<AddressDtos>> GetAllAsync();
        Task<AddressDtos> CreateAddressAsync(AddressDtos addressDtos);
        Task<AddressDtos> GetAddressByIdAsync(Guid AddressId);
        Task UpdateAddressAsync(AddressDtos addressDtos);
        Task DeleteAddressAsync(Guid AddressId);
    }
}
