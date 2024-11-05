using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PulpTicket.Application.DTOs
{
     public class PaymentDtos
    {
        public Guid PaymentID { get; set; }
        public decimal Amount { get; set; }
        public DateTime Time { get; set; }
        public string DiscountCouponId { get; set; }
        public string PaymentMethod { get; set; } // Renamed for clarity
        public Guid BookingId { get; set; }

       
    }
}
