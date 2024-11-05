using PulpTicket.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PulpTicket.Domain.Repositories
{
    public interface IPaymentRepository
    {
        Task<Payment> GetByIdAsync(Guid paymentId);
        Task<IEnumerable<Payment>> GetAllAsync();
        Task AddAsync(Payment payment);
        Task UpdateAsync(Payment payment);
        Task DeleteAsync(Guid paymentId);

    }
}
