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
    public class ShowSeatMapperProfile : Profile
    {
        public ShowSeatMapperProfile()
        {

            CreateMap<ShowSeat, ShowSeatDtos>()
                .ForMember(dest => dest.ShowSeatId, opt => opt.MapFrom(src => src.ShowSeatId))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price))
                .ForMember(dest => dest.ShowId, opt => opt.MapFrom(src => src.ShowId))
                .ForMember(dest => dest.BookingId, opt => opt.MapFrom(src => src.BookingId))
                .ReverseMap();
        }
    }
}
