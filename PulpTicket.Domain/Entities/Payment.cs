using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PulpTicket.Domain.Entities
{
    public class Payment
    {
        public Guid PaymentID { get; set; }
        public decimal Amount { get; set; }
        public DateTime Time { get; set; }
        public string DiscountCouponId { get; set; }
        public string PaymentMethod { get; set; } // Renamed for clarity
        public Guid BookingId { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public Guid CreatedBy { get; set; }
        public Guid UpdatedBy { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
    }
}



