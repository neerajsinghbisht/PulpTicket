using PulpTicket.Domain.Entities;
using PulpTicket.Domain.Repositories;
using System.Data;
using Dapper;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Data.Common;

namespace PulpTicket.Infrastructure.Repositories
{
    public class CityRepository : ICityRepository
    {
        private readonly IDbConnection _dbConnection;

        public CityRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<City> GetByIdAsync(Guid cityId)
        {
            var query = "SELECT * FROM dbo.[Cities] WHERE CityId = @CityId";
            return await _dbConnection.QueryFirstOrDefaultAsync<City>(query, new { CityId = cityId });
        }

        public async Task<IEnumerable<City>> GetAllAsync()
        {
            var query = "SELECT * FROM dbo.[Cities]";
            return await _dbConnection.QueryAsync<City>(query);
        }

        public async Task AddAsync(City city)
        {
            city.CityId = Guid.NewGuid();
           
            var query = @"
        INSERT INTO Cities (CityId, CityName, State, ZipCode, CreatedAt, UpdatedAt, CreatedBy, UpdatedBy, IsActive, IsDeleted) 
        VALUES (@CityId, @CityName, @State, @ZipCode, @CreatedAt, @UpdatedAt, @CreatedBy, @UpdatedBy, @IsActive, @IsDeleted)"
            ;

            await _dbConnection.ExecuteAsync(query, city);
        }

        public async Task UpdateAsync(City city)
        {
            // Check and assign current date if DateTime.MinValue is detected
         
            city.UpdatedAt = DateTime.Now; // Set the current time for UpdatedAt

            var query = @"
            UPDATE dbo.[Cities]
            SET CityName = @CityName, 
                State = @State, 
                ZipCode = @ZipCode, 
                CreatedAt = @CreatedAt, 
                UpdatedAt = @UpdatedAt, 
                CreatedBy = @CreatedBy, 
                UpdatedBy = @UpdatedBy, 
                IsActive = @IsActive, 
                IsDeleted = @IsDeleted
            WHERE CityId = @CityId";

            await _dbConnection.ExecuteAsync(query, city);
        }

        public async Task DeleteAsync(Guid cityId)
        {
            var query = "DELETE FROM dbo.[Cities] WHERE CityId = @CityId";
            await _dbConnection.ExecuteAsync(query, new { CityId = cityId });
        }
    }
}
