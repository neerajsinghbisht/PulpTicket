using PulpTicket.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PulpTicket.Domain.Repositories
{
    public interface IShowRepository
    {
        Task<Show> GetByIdAsync(Guid showId);
        Task<IEnumerable<Show>> GetAllAsync();
        Task AddAsync(Show show);
        Task UpdateAsync(Show show);
        Task DeleteAsync(Guid showId);
    }
}
