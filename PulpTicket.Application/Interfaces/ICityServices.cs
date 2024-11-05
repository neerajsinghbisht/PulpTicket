using PulpTicket.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PulpTicket.Application.Interfaces
{
    public interface ICityServices
    {
        Task<CityDtos> GetCityByIdAsync(Guid cityId);                     // Get a city by ID
        Task<IEnumerable<CityDtos>> GetAllCitiesAsync();                  // Get all cities
        Task<CityDtos> CreateCityAsync(CityDtos cityDto);                // Create a new city
        Task<CityDtos> UpdateCityAsync(CityDtos cityDto);                // Update an existing city
        Task DeleteCityAsync(Guid cityId);
    }
}
