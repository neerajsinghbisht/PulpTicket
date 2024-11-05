using Microsoft.AspNetCore.Mvc;
using PulpTicket.Application.DTOs;

namespace PulpTicket.Application.Interfaces
{
    public interface IMovieService
    {
        Task<IEnumerable<MovieDtos>> GetAllAsync(string? filterOn = null, string? filterQuery = null, string? sortBy = "Name",
    bool isDescending = false,
int pageNumber =1,int pageSIze=1000);
        
        Task<MovieDtos> CreateMovieAsync(MovieDtos movieDtos);
        Task<MovieDtos> GetMovieByIdAsync(Guid Movie_Id);

        //Task UpdateMovieAsync(MovieDtos movieDtos);
        Task DeleteMovieAsync(Guid Movie_Id);
    }
}
