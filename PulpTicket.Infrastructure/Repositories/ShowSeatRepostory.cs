using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Dapper;
using PulpTicket.Domain.Entities;
using PulpTicket.Domain.Repositories;

namespace PulpTicket.Infrastructure.Repositories
{
    public class ShowSeatRepository : IShowSeatRepository
    {
        private readonly IDbConnection _dbConnection;

        public ShowSeatRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<ShowSeat> GetByIdAsync(Guid showSeatId)
        {
            var query = "SELECT * FROM ShowSeat WHERE ShowSeatId = @ShowSeatId";
            return await _dbConnection.QueryFirstOrDefaultAsync<ShowSeat>(query, new { ShowSeatId = showSeatId });
        }

        public async Task<IEnumerable<ShowSeat>> GetAllAsync()
        {
            var query = "SELECT * FROM ShowSeat";
            return await _dbConnection.QueryAsync<ShowSeat>(query);
        }

        public async Task AddAsync(ShowSeat showSeat)
        {
            showSeat.ShowId = Guid.NewGuid();
            var query = @"
            INSERT INTO ShowSeat (ShowSeatId, Status, Price, ShowId, BookingId, CreatedAt, UpdatedAt, CreatedBy, UpdatedBy, IsActive, IsDeleted) 
            VALUES (@ShowSeatId, @Status, @Price, @ShowId, @BookingId, GETDATE(), NULL, @CreatedBy, @UpdatedBy, @IsActive, @IsDeleted)";

            await _dbConnection.ExecuteAsync(query, showSeat);
        }

        public async Task UpdateAsync(ShowSeat showSeat)
        {
           
            var query = @"
            UPDATE ShowSeat
            SET Status = @Status, 
                Price = @Price, 
                ShowId = @ShowId, 
                BookingId = @BookingId, 
                UpdatedAt = GETDATE(), 
                UpdatedBy = @UpdatedBy, 
                IsActive = @IsActive, 
                IsDeleted = @IsDeleted
            WHERE ShowSeatId = @ShowSeatId";

            await _dbConnection.ExecuteAsync(query, showSeat);
        }

        public async Task DeleteAsync(Guid showSeatId)
        {
            var query = "DELETE FROM ShowSeat WHERE ShowSeatId = @ShowSeatId";
            await _dbConnection.ExecuteAsync(query, new { ShowSeatId = showSeatId });
        }
    }
}

