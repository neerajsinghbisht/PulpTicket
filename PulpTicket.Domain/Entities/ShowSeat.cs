using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PulpTicket.Domain.Entities
{
    public class ShowSeat
    {
        public Guid ShowSeatId { get; set; } // ShowSeatID
        public string Status { get; set; } // Status of the seat (e.g., Available, Booked)
        public int Price { get; set; } // Price of the seat
        public Guid ShowId { get; set; } // Foreign key to the Show
        public Guid BookingId { get; set; } // Foreign key to the Booking

        public DateTime CreatedAt { get; set; } // Creation timestamp
        public DateTime? UpdatedAt { get; set; } // Update timestamp
        public Guid CreatedBy { get; set; } // ID of the user who created it
        public Guid UpdatedBy { get; set; } // ID of the user who updated it
        public bool IsActive { get; set; } // Indicates if the seat is active
        public bool IsDeleted { get; set; } // Indicates if the seat is deleted
    }
}
