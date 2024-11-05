using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PulpTicket.Application.DTOs
{
    public  class ShowSeatDtos
    {
        public Guid ShowSeatId { get; set; } // Unique identifier for the show seat
        public string Status { get; set; }    // Status of the seat (e.g., Available, Booked)
        public decimal Price { get; set; }     // Price of the seat
        public Guid ShowId { get; set; }       // Identifier for the associated show
        public Guid BookingId { get; set; }
    }
}
