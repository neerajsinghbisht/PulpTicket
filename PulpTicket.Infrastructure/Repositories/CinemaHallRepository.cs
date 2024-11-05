using Dapper;
using PulpTicket.Domain.Entities;
using PulpTicket.Domain.Repositories;
using System.Data;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace PulpTicket.Infrastructure.Repositories
{
    public class CinemaHallRepository : ICinemaHallRepository
    {
        private readonly IDbConnection _dbConnection;

        public CinemaHallRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<CinemaHall> GetByIdAsync(Guid cinemaHallId)
        {
            var query = "SELECT * FROM CinemaHall WHERE CinemaHallId = @CinemaHallId";
            return await _dbConnection.QueryFirstOrDefaultAsync<CinemaHall>(query, new { CinemaHallId = cinemaHallId });
        }

        public async Task<IEnumerable<CinemaHall>> GetAllAsync()
        {
            var query = "SELECT * FROM CinemaHall";
            return await _dbConnection.QueryAsync<CinemaHall>(query);
        }

        public async Task AddAsync(CinemaHall cinemaHall)
        {
            cinemaHall.CinemaHallId = Guid.NewGuid();
            
            cinemaHall.CreatedAt = cinemaHall.CreatedAt == DateTime.MinValue ? DateTime.Now : cinemaHall.CreatedAt;

            // Ensure UpdatedAt is null initially
            cinemaHall.UpdatedAt = cinemaHall.UpdatedAt == DateTime.MinValue ? (DateTime?)null : cinemaHall.UpdatedAt;

            var query = @"
                INSERT INTO CinemaHall (CinemaHallId, Name, TotalSeats, CityId, CreatedAt, UpdatedAt, CreatedBy, UpdatedBy, IsActive, IsDeleted) 
                VALUES (@CinemaHallId, @Name, @TotalSeats, @CityId, @CreatedAt, @UpdatedAt, @CreatedBy, @UpdatedBy, @IsActive, @IsDeleted)";

            await _dbConnection.ExecuteAsync(query, cinemaHall);
        }

        public async Task UpdateAsync(CinemaHall cinemaHall)
        {
            cinemaHall.UpdatedAt = DateTime.Now;
            var query = @"
                UPDATE CinemaHall
                SET Name = @Name, 
                    TotalSeats = @TotalSeats, 
                    CityId= @CityId,
                    UpdatedAt = @UpdatedAt,
                    UpdatedBy = @UpdatedBy,
                    IsActive = @IsActive,
                    IsDeleted = @IsDeleted
                WHERE CinemaHallId = @CinemaHallId";

            await _dbConnection.ExecuteAsync(query, cinemaHall);
        }

        public async Task DeleteAsync(Guid cinemaHallId)
        {
            var query = "DELETE FROM CinemaHall WHERE CinemaHallId = @CinemaHallId";
            await _dbConnection.ExecuteAsync(query, new { CinemaHallId = cinemaHallId });
        }
    }
}

