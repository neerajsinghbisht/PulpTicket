using PulpTicket.Domain.Entities;
using PulpTicket.Domain.Repositories;
using System.Data;
using Dapper;
using System.Data.Common;
namespace PulpTicket.Infrastructure.Repositories
{
    
        public class ShowRepository : IShowRepository
        {
            private readonly IDbConnection _dbConnection;

            public ShowRepository(IDbConnection dbConnection)
            {
                _dbConnection = dbConnection;
            }

            public async Task<Show> GetByIdAsync(Guid showId)
            {
                var query = "SELECT * FROM dbo.[Show] WHERE ShowId = @ShowId";
                return await _dbConnection.QueryFirstOrDefaultAsync<Show>(query, new { ShowId = showId });
            }

            public async Task<IEnumerable<Show>> GetAllAsync()
            {
                var query = "SELECT * FROM dbo.[Show]";
                return await _dbConnection.QueryAsync<Show>(query);
            }

            public async Task AddAsync(Show entity)
            {
            entity.ShowId = Guid.NewGuid();
            entity.UpdatedBy = entity.ShowId;
                var query = @"
            INSERT INTO [Show] (ShowId, Date, StartTime, EndTime, CinemaHallId, CreatedAt, UpdatedAt, CreatedBy, UpdatedBy, IsActive, IsDeleted)
            VALUES (@ShowId, @Date, @StartTime, @EndTime, @CinemaHallId, GETDATE(), NULL, @CreatedBy, @UpdatedBy, @IsActive, @IsDeleted)";

                await _dbConnection.ExecuteAsync(query, entity);
            }

            public async Task UpdateAsync(Show entity)
            {
                // Check and assign current date if DateTime.MinValue is detected
                entity.CreatedAt = (entity.CreatedAt == DateTime.MinValue) ? DateTime.Now : entity.CreatedAt;
                entity.UpdatedAt = (entity.UpdatedAt == DateTime.MinValue) ? DateTime.Now : entity.UpdatedAt;
            entity.UpdatedBy = entity.ShowId;
                var query = @"
            UPDATE dbo.[Show]
            SET Date = @Date, 
                StartTime = @StartTime, 
                EndTime = @EndTime, 
                CinemaHallId = @CinemaHallId, 
                CreatedAt = @CreatedAt, 
                UpdatedAt = @UpdatedAt, 
                CreatedBy = @CreatedBy, 
                UpdatedBy = @UpdatedBy, 
                IsActive = @IsActive, 
                IsDeleted = @IsDeleted
            WHERE ShowId = @ShowId";

                await _dbConnection.ExecuteAsync(query, entity);
            }

            public async Task DeleteAsync(Guid showId)
            {
                var query = "DELETE FROM dbo.[Show] WHERE ShowId = @ShowId";
                await _dbConnection.ExecuteAsync(query, new { ShowId = showId });
            }
        }
    }

