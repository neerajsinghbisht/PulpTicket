// File: PulpTicket.Application/Services/PaymentServices.cs
using AutoMapper;
using PulpTicket.Application.DTOs;
using PulpTicket.Application.Interfaces;
using PulpTicket.Domain.Entities;
using PulpTicket.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PulpTicket.Application.Services
{
    public class PaymentServices : IPaymentServices
    {
        private readonly IPaymentRepository _paymentRepository;
        private readonly IMapper _mapper;

        public PaymentServices(IPaymentRepository paymentRepository, IMapper mapper)
        {
            _paymentRepository = paymentRepository;
            _mapper = mapper;
        }

        public async Task<PaymentDtos> GetPaymentByIdAsync(Guid paymentId)
        {
            var payment = await _paymentRepository.GetByIdAsync(paymentId);
            return _mapper.Map<PaymentDtos>(payment);
        }

        public async Task<IEnumerable<PaymentDtos>> GetAllPaymentsAsync()
        {
            var payments = await _paymentRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<PaymentDtos>>(payments);
        }

        public async Task<PaymentDtos> CreatePaymentAsync(PaymentDtos paymentDto)
        {
            var payment = _mapper.Map<Payment>(paymentDto);
            await _paymentRepository.AddAsync(payment);
            return _mapper.Map<PaymentDtos>(payment);
        }

        public async Task<PaymentDtos> UpdatePaymentAsync(PaymentDtos paymentDto)
        {
            var payment = _mapper.Map<Payment>(paymentDto);
            await _paymentRepository.UpdateAsync(payment);
            return paymentDto; // Return the updated DTO
        }

        public async Task DeletePaymentAsync(Guid paymentId)
        {
            await _paymentRepository.DeleteAsync(paymentId);
        }
    }
}

