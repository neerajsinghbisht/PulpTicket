using PulpTicket.Application.DTOs;
using System;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Net;
using PulpTicket.Domain.Entities;

namespace PulpTicket.Application.Mappers

{
    public class AddressProfile : Profile
    {
        public AddressProfile()
        {
            CreateMap<Address, AddressDtos>()
                .ForMember(dest => dest.Address_Id, opt => opt.MapFrom(src => src.Address_Id))
                .ForMember(dest => dest.Street_Address, opt => opt.MapFrom(src => src.Street_Address))
                .ForMember(dest => dest.City, opt => opt.MapFrom(src => src.City))
                .ForMember(dest => dest.State, opt => opt.MapFrom(src => src.State))
                .ForMember(dest => dest.Zipcode, opt => opt.MapFrom(src => src.Zipcode))
                
                .ReverseMap(); // Enables reverse mapping from AddressDtos to Address if needed
        }
    }
   

}
