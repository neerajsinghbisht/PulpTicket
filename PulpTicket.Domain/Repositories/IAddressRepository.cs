using PulpTicket.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PulpTicket.Domain.Repositories
{
    public interface IAddressRepository
    {
        Task<Address> GetByIdAsync(Guid Address_id);
        Task<IEnumerable<Address>> GetAllAsync();
        Task AddAsync(Address entity);
        Task UpdateAsync(Address entity);
        Task DeleteAsync(Guid Address_id);
    }
}
