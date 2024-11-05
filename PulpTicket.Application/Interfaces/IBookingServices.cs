using PulpTicket.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PulpTicket.Application.Interfaces
{
    public interface IBookingServices
    {
        Task<BookingDtos> GetBookingByIdAsync(Guid bookingId);
        Task<IEnumerable<BookingDtos>> GetAllBookingsAsync();
        Task<BookingDtos> CreateBookingAsync(BookingDtos bookingDto);
        Task<BookingDtos> UpdateBookingAsync(BookingDtos bookingDto);
        Task DeleteBookingAsync(Guid bookingId);
    }
}

