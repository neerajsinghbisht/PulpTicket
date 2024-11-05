using AutoMapper;
using PulpTicket.Application.DTOs;
using PulpTicket.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PulpTicket.Application.Mappers
{
    public class CinemaHallMappingProfile : Profile
    {
        public CinemaHallMappingProfile()
        {
            // Mapping from CinemaHall entity to CinemaHallDtos
            CreateMap<CinemaHall, CinemaHallDtos>()
                .ForMember(dest => dest.CinemaHallId, opt => opt.MapFrom(src => src.CinemaHallId))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.TotalSeats, opt => opt.MapFrom(src => src.TotalSeats))
                .ForMember(dest => dest.CityId, opt => opt.MapFrom(src => src.CityId))
                .ReverseMap();
        }
    }

}

