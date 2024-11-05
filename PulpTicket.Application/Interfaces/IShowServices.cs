using PulpTicket.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PulpTicket.Application.Interfaces
{
    public interface IShowServices
    {
        Task<ShowDtos> GetShowByIdAsync(Guid showId);
        Task<IEnumerable<ShowDtos>> GetAllShowsAsync();
        Task<ShowDtos> CreateShowAsync(ShowDtos showDto);
        Task<ShowDtos> UpdateShowAsync(ShowDtos showDto);
        Task DeleteShowAsync(Guid showId);
    }
}
