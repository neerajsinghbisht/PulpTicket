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
    public class CityMapperProfile : Profile
    {
        public CityMapperProfile()
        {
            // Mapping from City to CityDtos
            CreateMap<City, CityDtos>()
                .ForMember(dest => dest.CityId, opt => opt.MapFrom(src => src.CityId))
                .ForMember(dest => dest.CityName, opt => opt.MapFrom(src => src.CityName))
                .ForMember(dest => dest.State, opt => opt.MapFrom(src => src.State))
                .ForMember(dest => dest.ZipCode, opt => opt.MapFrom(src => src.ZipCode))
                .ReverseMap();
        }
    }
}
