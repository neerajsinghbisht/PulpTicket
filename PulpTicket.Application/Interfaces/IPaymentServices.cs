using PulpTicket.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PulpTicket.Application.Interfaces
{
    public interface IPaymentServices
    {
        Task<PaymentDtos> GetPaymentByIdAsync(Guid paymentId);
        Task<IEnumerable<PaymentDtos>> GetAllPaymentsAsync();
        Task<PaymentDtos> CreatePaymentAsync(PaymentDtos paymentDto);
        Task<PaymentDtos> UpdatePaymentAsync(PaymentDtos paymentDto);
        Task DeletePaymentAsync(Guid paymentId);
    }
}
