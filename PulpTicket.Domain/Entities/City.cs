using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PulpTicket.Domain.Entities
{
    public class City
    {
        public Guid CityId { get; set; }           // Unique identifier for the city
        public string CityName { get; set; }       // Name of the city
        public string State { get; set; }           // State in which the city is located
        public string ZipCode { get; set; }         // Zip code of the city
        public DateTime CreatedAt { get; set; }     // Creation timestamp
        public DateTime UpdatedAt { get; set; }     // Last update timestamp
        public Guid CreatedBy { get; set; }         // User who created the record
        public Guid UpdatedBy { get; set; }         // User who last updated the record
        public bool IsActive { get; set; }          // Indicates if the city is active
        public bool IsDeleted { get; set; }
    }
}
