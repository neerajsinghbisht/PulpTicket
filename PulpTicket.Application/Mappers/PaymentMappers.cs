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
    public class PaymentProfile : Profile
    {
        public PaymentProfile()
        {
            // Mapping from Payment entity to PaymentDtos
            CreateMap<Payment, PaymentDtos>()
                .ForMember(dest => dest.PaymentID, opt => opt.MapFrom(src => src.PaymentID))
                .ForMember(dest => dest.Amount, opt => opt.MapFrom(src => src.Amount))
                .ForMember(dest => dest.Time, opt => opt.MapFrom(src => src.Time))
                .ForMember(dest => dest.DiscountCouponId, opt => opt.MapFrom(src => src.DiscountCouponId))
                .ForMember(dest => dest.PaymentMethod, opt => opt.MapFrom(src => src.PaymentMethod))
                .ForMember(dest => dest.BookingId, opt => opt.MapFrom(src => src.BookingId))
                .ReverseMap();
        }
    }
}
