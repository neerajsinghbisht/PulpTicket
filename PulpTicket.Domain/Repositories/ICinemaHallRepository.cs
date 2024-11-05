using PulpTicket.Domain.Entities;

namespace PulpTicket.Domain.Repositories
{
    public interface ICinemaHallRepository
    {
        Task<CinemaHall> GetByIdAsync(Guid cinemaHallId);                    // Get a cinema hall by ID
        Task<IEnumerable<CinemaHall>> GetAllAsync();                         // Get all cinema halls
        Task AddAsync(CinemaHall cinemaHall);                                 // Add a new cinema hall
        Task UpdateAsync(CinemaHall cinemaHall);                              // Update an existing cinema hall
        Task DeleteAsync(Guid cinemaHallId);
    }
}
