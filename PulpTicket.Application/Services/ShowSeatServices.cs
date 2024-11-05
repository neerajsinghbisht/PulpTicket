using AutoMapper;
using PulpTicket.Application.DTOs;
using PulpTicket.Application.Interfaces;
using PulpTicket.Domain.Entities;
using PulpTicket.Domain.Repositories;

namespace PulpTicket.Application.Services
{
    public class ShowSeatService : IShowSeatServices
    {
        private readonly IShowSeatRepository _showSeatRepository;
        private readonly IMapper _mapper;

        public ShowSeatService(IShowSeatRepository showSeatRepository, IMapper mapper)
        {
            _showSeatRepository = showSeatRepository;
            _mapper = mapper;
        }

        public async Task<ShowSeatDtos> GetShowSeatByIdAsync(Guid showSeatId)
        {
            var showSeat = await _showSeatRepository.GetByIdAsync(showSeatId);
            return _mapper.Map<ShowSeatDtos>(showSeat);
        }

        public async Task<IEnumerable<ShowSeatDtos>> GetAllShowSeatsAsync()
        {
            var showSeats = await _showSeatRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<ShowSeatDtos>>(showSeats);
        }

        public async Task<ShowSeatDtos> CreateShowSeatAsync(ShowSeatDtos showSeatDto)
        {
            var showSeat = _mapper.Map<ShowSeat>(showSeatDto);
            await _showSeatRepository.AddAsync(showSeat);
            return _mapper.Map<ShowSeatDtos>(showSeat);
        }

        public async Task<ShowSeatDtos> UpdateShowSeatAsync(ShowSeatDtos showSeatDto)
        {
            var showSeat = _mapper.Map<ShowSeat>(showSeatDto);
            await _showSeatRepository.UpdateAsync(showSeat);
            return _mapper.Map<ShowSeatDtos>(showSeat);
        }

        public async Task DeleteShowSeatAsync(Guid showSeatId)
        {
            await _showSeatRepository.DeleteAsync(showSeatId);
        }
    }
}
