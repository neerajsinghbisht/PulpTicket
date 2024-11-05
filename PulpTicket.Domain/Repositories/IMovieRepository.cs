using PulpTicket.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PulpTicket.Domain.Repositories
{
    public interface IMovieRepository
    {
        Task<Movie> GetByIdAsync(Guid Address_id);
        Task<IEnumerable<Movie>> GetAllAsync(string? filterOn = null, string? filterQuery = null,string ? sortBy = "Name",
    bool isDescending = false, int pageNumber=1,int pageSize=1000);
        Task AddAsync(Movie entity);
        //Task UpdateAsync(Movie entity);
        Task DeleteAsync(Guid Movie_id);
    }
}
