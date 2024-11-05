using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PulpTicket.Application.DTOs
{
    public class MovieDtos
    {
        [Required]
        
        public Guid Movie_Id { get; set; }

        [Required]
        [MinLength(3,ErrorMessage ="provide minimum length of 3")]
        public string Name { get; set; }
        public string Language { get; set; }
        public string Genre { get; set; }
        public string Cast { get; set; }
        public string Image { get; set; }
        //public DateTime CreatedAt { get; set; }
        //public DateTime? UpdatedAt { get; set; }
        //public Guid? CreatedBy { get; set; }
        //public Guid? UpdatedBy { get; set; }
        //public bool IsActive { get; set; }
        //public bool IsDeleted { get; set; }
    }
}
