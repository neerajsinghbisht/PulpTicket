using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PulpTicket.Application.DTOs
{
    public class ShowDtos
    {
        public Guid ShowId { get; set; }
        public DateTime Date { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public Guid CinemaHallId { get; set; }
       
    }
}
