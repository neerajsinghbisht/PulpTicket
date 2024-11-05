using AutoMapper;
using PulpTicket.Application.DTOs;
using PulpTicket.Application.Interfaces;
using PulpTicket.Domain.Entities;
using PulpTicket.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PulpTicket.Application.Services
{
    public class BookingService : IBookingServices
    {
        private readonly IBookingRepository _bookingRepository;
        private readonly IMapper _mapper;

        public BookingService(IBookingRepository bookingRepository, IMapper mapper)
        {
            _bookingRepository = bookingRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<BookingDtos>> GetAllBookingsAsync()
        {
            var bookings = await _bookingRepository.GetAllBookingsAsync();
            return _mapper.Map<IEnumerable<BookingDtos>>(bookings);
        }

        public async Task<BookingDtos> CreateBookingAsync(BookingDtos bookingDto)
        {
            var booking = _mapper.Map<Booking>(bookingDto);
            await _bookingRepository.AddAsync(booking);
            return _mapper.Map<BookingDtos>(booking);
        }

        public async Task<BookingDtos> GetBookingByIdAsync(Guid bookingId)
        {
            var booking = await _bookingRepository.GetByIdAsync(bookingId);
            return _mapper.Map<BookingDtos>(booking);
        }

        public async Task<BookingDtos> UpdateBookingAsync(BookingDtos bookingDto)
        {
            var booking = _mapper.Map<Booking>(bookingDto);
            await _bookingRepository.UpdateBookingAsync(booking);
            return _mapper.Map<BookingDtos>(booking);
        }

        public async Task DeleteBookingAsync(Guid bookingId)
        {
            await _bookingRepository.DeleteAsync(bookingId);
        }
    }
}
