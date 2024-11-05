using PulpTicket.Domain.Entities;
using PulpTicket.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Dapper;

namespace PulpTicket.Infrastructure.Repositories
{
    public class BookingRepository : IBookingRepository
    {
        private readonly IDbConnection _dbConnection;

        public BookingRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<Booking> GetByIdAsync(Guid bookingId)
        {
            var query = "SELECT * FROM dbo.[Booking] WHERE Booking_Id = @BookingId";
            return await _dbConnection.QueryFirstOrDefaultAsync<Booking>(query, new { BookingId = bookingId });
        }

        public async Task<IEnumerable<Booking>> GetAllBookingsAsync()
        {
            var query = "SELECT * FROM dbo.[Booking]";
            return await _dbConnection.QueryAsync<Booking>(query);
        }

        public async Task AddAsync(Booking entity)
        {
            var existingBooking = await GetByIdAsync(entity.Booking_Id);
            if (existingBooking != null)
            {
                // Generate a new ID if a duplicate is found
                entity.Booking_Id = Guid.NewGuid();
            }

            var query = @"
                INSERT INTO [Booking] 
                (Booking_Id, NumberOfSeats, Status, Id, Show_Id, CreatedAt, UpdatedAt, CreatedBy, UpdatedBy, IsActive, IsDeleted) 
                VALUES 
                (@Booking_Id, @NumberOfSeats, @Status, @Id, @Show_Id, GETDATE(), NULL, @CreatedBy, @UpdatedBy, @IsActive, @IsDeleted)";

            await _dbConnection.ExecuteAsync(query, entity);
        }

        public async Task UpdateBookingAsync(Booking entity)
        {
            entity.CreatedAt = (entity.CreatedAt == DateTime.MinValue) ? DateTime.Now : entity.CreatedAt;
            entity.UpdatedAt = DateTime.Now;

            var query = @"
                UPDATE dbo.[Booking]
                SET NumberOfSeats = @NumberOfSeats,
                    Status = @Status,
                    Id = @Id,
                    Show_Id = @Show_Id,
                    CreatedAt = @CreatedAt,
                    UpdatedAt = @UpdatedAt,
                    CreatedBy = @CreatedBy,
                    UpdatedBy = @UpdatedBy,
                    IsActive = @IsActive,
                    IsDeleted = @IsDeleted
                WHERE Booking_Id = @Booking_Id";

            await _dbConnection.ExecuteAsync(query, entity);
        }

        public async Task DeleteAsync(Guid bookingId)
        {
            var query = "DELETE FROM dbo.[Booking] WHERE Booking_Id = @BookingId";
            await _dbConnection.ExecuteAsync(query, new { BookingId = bookingId });
        }
    }
}
