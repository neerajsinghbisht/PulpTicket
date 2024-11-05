using PulpTicket.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PulpTicket.Application.Interfaces
{
    public interface IShowSeatServices
    {
        Task<ShowSeatDtos> GetShowSeatByIdAsync(Guid showSeatId);
        Task<IEnumerable<ShowSeatDtos>> GetAllShowSeatsAsync();
        Task<ShowSeatDtos> CreateShowSeatAsync(ShowSeatDtos showSeatDto);
        Task<ShowSeatDtos> UpdateShowSeatAsync(ShowSeatDtos showSeatDto);
        Task DeleteShowSeatAsync(Guid showSeatId);
    }
}
