using PulpTicket.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PulpTicket.Domain.Repositories
{
    public interface IBookingRepository
    {
        Task<Booking> GetByIdAsync(Guid bookingId);
        Task<IEnumerable<Booking>> GetAllBookingsAsync();
        Task AddAsync(Booking booking);
        Task UpdateBookingAsync(Booking booking);
        Task DeleteAsync(Guid bookingId);
    }
}
