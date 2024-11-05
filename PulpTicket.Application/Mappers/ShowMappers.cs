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
    public class ShowProfile : Profile
    {
        public ShowProfile()
        {
            // Mapping from Show entity to ShowDtos
            CreateMap<Show, ShowDtos>()
                .ForMember(dest => dest.ShowId, opt => opt.MapFrom(src => src.ShowId))
                .ForMember(dest => dest.Date, opt => opt.MapFrom(src => src.Date))
                .ForMember(dest => dest.StartTime, opt => opt.MapFrom(src => src.StartTime))
                .ForMember(dest => dest.EndTime, opt => opt.MapFrom(src => src.EndTime))
                .ForMember(dest => dest.CinemaHallId, opt => opt.MapFrom(src => src.CinemaHallId))
                .ReverseMap();


        }
    }
}
