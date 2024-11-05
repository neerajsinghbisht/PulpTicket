using AutoMapper;
using PulpTicket.Application.DTOs;
using PulpTicket.Domain.Entities;


namespace PulpTicket.Application.Mappers
{
    public class BookingProfile : Profile
    {
        public BookingProfile()
        {
            CreateMap<Booking, BookingDtos>()
                .ForMember(dest => dest.Booking_Id, opt => opt.MapFrom(src => src.Booking_Id))
                .ForMember(dest => dest.NumberOfSeats, opt => opt.MapFrom(src => src.NumberOfSeats))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status))
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Show_Id, opt => opt.MapFrom(src => src.Show_Id))
                
               .ReverseMap(); // Enables reverse mapping from BookingDto to Booking if needed
        }
    }
}
