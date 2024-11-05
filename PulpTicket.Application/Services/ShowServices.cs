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
    
        public class ShowServices : IShowServices
        {
            private readonly IShowRepository _showRepository;
            private readonly IMapper _mapper;

            public ShowServices(IShowRepository showRepository, IMapper mapper)
            {
                _showRepository = showRepository;
                _mapper = mapper;
            }

            public async Task<IEnumerable<ShowDtos>> GetAllShowsAsync()
            {
                var shows = await _showRepository.GetAllAsync();
                return _mapper.Map<IEnumerable<ShowDtos>>(shows);
            }

            public async Task<ShowDtos> CreateShowAsync(ShowDtos showDto)
            {
                var show = _mapper.Map<Show>(showDto);
                await _showRepository.AddAsync(show);
                return _mapper.Map<ShowDtos>(show);
            }

            public async Task<ShowDtos> GetShowByIdAsync(Guid showId)
            {
                var show = await _showRepository.GetByIdAsync(showId);
                return _mapper.Map<ShowDtos>(show);
            }

            public async Task<ShowDtos> UpdateShowAsync(ShowDtos showDto)
            {
                var show = _mapper.Map<Show>(showDto);
                await _showRepository.UpdateAsync(show);
                return _mapper.Map<ShowDtos>(show);
            }

            public async Task DeleteShowAsync(Guid showId)
            {
                await _showRepository.DeleteAsync(showId);
            }
        }
    }

