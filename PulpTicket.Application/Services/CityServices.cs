// PulpTicket.Application/Services/CityServices.cs
using AutoMapper;
using PulpTicket.Application.DTOs;
using PulpTicket.Application.Interfaces;
using PulpTicket.Domain.Entities;
using PulpTicket.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PulpTicket.Application.Services
{
    public class CityServices : ICityServices
    {
        private readonly ICityRepository _cityRepository; // Repository for accessing city data
        private readonly IMapper _mapper; // AutoMapper instance for mapping between entities and DTOs

        public CityServices(ICityRepository cityRepository, IMapper mapper)
        {
            _cityRepository = cityRepository;
            _mapper = mapper;
        }

        public async Task<CityDtos> GetCityByIdAsync(Guid cityId)
        {
            var city = await _cityRepository.GetByIdAsync(cityId);
            return _mapper.Map<CityDtos>(city); // Map entity to DTO
        }

        public async Task<IEnumerable<CityDtos>> GetAllCitiesAsync()
        {
            var cities = await _cityRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<CityDtos>>(cities); // Map entities to DTOs
        }

        public async Task<CityDtos> CreateCityAsync(CityDtos cityDtos)
        {
            var city = _mapper.Map<City>(cityDtos); // Map DTO to entity
            await _cityRepository.AddAsync(city); // Add entity to the repository
            return _mapper.Map<CityDtos>(city); // Return the created city as a DTO
        }

        public async Task<CityDtos> UpdateCityAsync(CityDtos cityDtos)
        {
            var city = _mapper.Map<City>(cityDtos); // Map DTO to entity
            await _cityRepository.UpdateAsync(city); // Update entity in the repository
            return _mapper.Map<CityDtos>(city); // Return the updated city as a DTO
        }

        public async Task DeleteCityAsync(Guid cityId)
        {
            await _cityRepository.DeleteAsync(cityId); // Delete city by ID from the repository
        }
    }
}
