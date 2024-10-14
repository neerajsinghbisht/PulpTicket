using PulpTicket.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PulpTicket.Domain.Entities;
using System.Threading.Tasks;

namespace PulpTicket.Application.Interfaces
{
    public interface IMovieRepository

    {
        Task<IEnumerable<Movie>> GetAllMoviesAsync();
        Task<Movie> GetMovieByIdAsync(Guid id);
        Task AddMovieAsync(Movie movie);
        Task UpdateMovieAsync(Movie movie);
        Task DeleteMovieAsync(Guid id);
    }
    
}
