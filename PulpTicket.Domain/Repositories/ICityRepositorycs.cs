using PulpTicket.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PulpTicket.Domain.Repositories
{
    public interface ICityRepository
    {
        Task<City> GetByIdAsync(Guid cityId);                              // Get a city by ID
        Task<IEnumerable<City>> GetAllAsync();                             // Get all cities
        Task AddAsync(City city);                                          // Add a new city
        Task UpdateAsync(City city);                                       // Update an existing city
        Task DeleteAsync(Guid cityId);
    }
}
