using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PulpTicket.Application.DTOs
{
    internal class MovieDtos
    {
        public Guid Movie_Id { get; set; }
        public string Name { get; set; }
        public string Language { get; set; }
        public string Genre { get; set; }
        public string Cast { get; set; }
        public string Image { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public Guid? CreatedBy { get; set; }
        public Guid? UpdatedBy { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
    }
}
