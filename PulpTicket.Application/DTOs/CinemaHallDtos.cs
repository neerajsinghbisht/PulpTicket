using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PulpTicket.Application.DTOs
{
    public class CinemaHallDtos
    {
        public Guid CinemaHallId { get; set; }        // Unique identifier for the cinema hall
        public string Name { get; set; }              // Name of the cinema hall
        public int TotalSeats { get; set; }           // Total number of seats
        public Guid CityId{ get; set; }
    }
}
