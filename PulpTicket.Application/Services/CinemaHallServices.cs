using AutoMapper;
using PulpTicket.Application.DTOs;
using PulpTicket.Application.Interfaces;
using PulpTicket.Domain.Entities;
using PulpTicket.Domain.Repositories;

namespace PulpTicket.Application.Services
{
    public class CinemaHallService : ICinemaHallServices
    {
        private readonly ICinemaHallRepository _cinemaHallRepository;
        private readonly IMapper _mapper;

        public CinemaHallService(ICinemaHallRepository cinemaHallRepository, IMapper mapper)
        {
            _cinemaHallRepository = cinemaHallRepository;
            _mapper = mapper;
        }

        public async Task<CinemaHallDtos> GetCinemaHallByIdAsync(Guid cinemaHallId)
        {
            var cinemaHall = await _cinemaHallRepository.GetByIdAsync(cinemaHallId);
            return _mapper.Map<CinemaHallDtos>(cinemaHall);
        }

        public async Task<IEnumerable<CinemaHallDtos>> GetAllCinemaHallsAsync()
        {
            var cinemaHalls = await _cinemaHallRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<CinemaHallDtos>>(cinemaHalls);
        }

        public async Task<CinemaHallDtos> CreateCinemaHallAsync(CinemaHallDtos cinemaHallDto)
        {
            var cinemaHall = _mapper.Map<CinemaHall>(cinemaHallDto);
            await _cinemaHallRepository.AddAsync(cinemaHall);
            return _mapper.Map<CinemaHallDtos>(cinemaHall);
        }

        public async Task<CinemaHallDtos> UpdateCinemaHallAsync(CinemaHallDtos cinemaHallDto)
        {
            var cinemaHall = _mapper.Map<CinemaHall>(cinemaHallDto);
            await _cinemaHallRepository.UpdateAsync(cinemaHall);
            return _mapper.Map<CinemaHallDtos>(cinemaHall);
        }

        public async Task DeleteCinemaHallAsync(Guid cinemaHallId)
        {
            await _cinemaHallRepository.DeleteAsync(cinemaHallId);
        }
    }
}
