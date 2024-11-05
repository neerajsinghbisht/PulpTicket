﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PulpTicket.Domain.Entities
{
    public class CinemaHall
    {
        public Guid CinemaHallId { get; set; }        // Unique identifier for the cinema hall
        public string Name { get; set; }              // Name of the cinema hall
        public int TotalSeats { get; set; }           // Total number of seats
        public Guid CityId { get; set; }            // Reference to the cinema
        public DateTime CreatedAt { get; set; }       // Creation timestamp
        public DateTime? UpdatedAt { get; set; }      // Update timestamp (nullable)
        public Guid CreatedBy { get; set; }            // ID of the user who created it
        public Guid? UpdatedBy { get; set; }          // ID of the user who updated it (nullable)
        public bool IsActive { get; set; }            // Status of the cinema hall
        public bool IsDeleted { get; set; }
    }
}