using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PulpTicket.Application.DTOs
{
    public class BookingDtos
    {
        public Guid Booking_Id { get; set; }
        public int NumberOfSeats { get; set; }
        public BookingStatus Status { get; set; }
        public Guid Id { get; set; }
        public Guid Show_Id { get; set; }
        
    }

    public enum BookingStatus
    {
        Pending = 0,
        Confirmed = 1,
        Canceled = 2
    }
}

