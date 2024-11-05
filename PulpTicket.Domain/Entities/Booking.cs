using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PulpTicket.Domain.Entities
{
    public class Booking
    {
        public Guid Booking_Id { get; set; }
        public int NumberOfSeats { get; set; }
        public BookingStatus Status { get; set; }
        public Guid Id { get; set; }
        public Guid Show_Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public Guid CreatedBy { get; set; }
        public Guid UpdatedBy { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
    }

    public enum BookingStatus
    {
        Pending = 0,
        Confirmed = 1,
        Canceled = 2
    }

}

