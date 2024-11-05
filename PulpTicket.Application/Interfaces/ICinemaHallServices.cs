using PulpTicket.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PulpTicket.Application.Interfaces
{
    public interface ICinemaHallServices
    {
        Task<CinemaHallDtos> GetCinemaHallByIdAsync(Guid cinemaHallId);            // Get a cinema hall by ID
        Task<IEnumerable<CinemaHallDtos>> GetAllCinemaHallsAsync();                // Get all cinema halls
        Task<CinemaHallDtos> CreateCinemaHallAsync(CinemaHallDtos cinemaHallDto);  // Create a new cinema hall
        Task<CinemaHallDtos> UpdateCinemaHallAsync(CinemaHallDtos cinemaHallDto);  // Update an existing cinema hall
        Task DeleteCinemaHallAsync(Guid cinemaHallId);
    }
}
