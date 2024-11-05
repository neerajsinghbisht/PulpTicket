using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AutoMapper;
using PulpTicket.Domain.Entities;
using PulpTicket.Application.DTOs;

namespace PulpTicket.Application.Mappers
{
    public class MovieProfile : Profile
    {
        public MovieProfile()
        {

            CreateMap<Movie, MovieDtos>()
                .ForMember(dest => dest.Movie_Id, opt => opt.MapFrom(src => src.Movie_Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Language, opt => opt.MapFrom(src => src.Language))
                .ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Genre))
                .ForMember(dest => dest.Cast, opt => opt.MapFrom(src => src.Cast))
                .ForMember(dest => dest.Image, opt => opt.MapFrom(src => src.Image))
                //.ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => src.CreatedAt))
                //.ForMember(dest => dest.UpdatedAt, opt => opt.MapFrom(src => src.UpdatedAt))
                //.ForMember(dest => dest.CreatedBy, opt => opt.MapFrom(src => src.CreatedBy))
                //.ForMember(dest => dest.UpdatedBy, opt => opt.MapFrom(src => src.UpdatedBy))
                //.ForMember(dest => dest.IsActive, opt => opt.MapFrom(src => src.IsActive))
                //.ForMember(dest => dest.IsDeleted, opt => opt.MapFrom(src => src.IsDeleted))
                .ReverseMap();
        }
    }
}
