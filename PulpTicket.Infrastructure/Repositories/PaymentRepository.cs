using PulpTicket.Domain.Entities;
using PulpTicket.Domain.Repositories;
using System.Data;
using Dapper;


namespace PulpTicket.Infrastructure.Repositories
{
    public class PaymentRepository : IPaymentRepository
    {
        private readonly IDbConnection _dbConnection;

        public PaymentRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<Payment> GetByIdAsync(Guid paymentId)
        {
            var query = "SELECT * FROM dbo.[Payment] WHERE PaymentID = @PaymentID";
            return await _dbConnection.QueryFirstOrDefaultAsync<Payment>(query, new { PaymentID = paymentId });
        }

        public async Task<IEnumerable<Payment>> GetAllAsync()
        {
            var query = "SELECT * FROM dbo.[Payment]";
            return await _dbConnection.QueryAsync<Payment>(query);
        }

        public async Task AddAsync(Payment payment)
        {
            var query = @"
                INSERT INTO [Payment] 
                (PaymentID, Amount, Time, DiscountCouponID, PaymentMethod, BookingID, CreatedAt, UpdatedAt, CreatedBy, UpdatedBy, IsActive, IsDeleted) 
                VALUES 
                (@PaymentID, @Amount, @Time, @DiscountCouponID, @PaymentMethod, @BookingID, GETDATE(), NULL, @CreatedBy, @UpdatedBy, @IsActive, @IsDeleted)";

            await _dbConnection.ExecuteAsync(query, payment);
        }

        public async Task UpdateAsync(Payment payment)
        {
            // Check and assign current date if DateTime.MinValue is detected
            payment.CreatedAt = (payment.CreatedAt == DateTime.MinValue) ? DateTime.Now : payment.CreatedAt;
            payment.UpdatedAt = (payment.UpdatedAt == DateTime.MinValue) ? DateTime.Now : payment.UpdatedAt;

            var query = @"
                UPDATE dbo.[Payment]
                SET Amount = @Amount, 
                    Time = @Time, 
                    DiscountCouponID = @DiscountCouponID, 
                    PaymentMethod = @PaymentMethod, 
                    BookingID = @BookingID, 
                    CreatedAt = @CreatedAt, 
                    UpdatedAt = @UpdatedAt, 
                    CreatedBy = @CreatedBy, 
                    UpdatedBy = @UpdatedBy, 
                    IsActive = @IsActive, 
                    IsDeleted = @IsDeleted
                WHERE PaymentID = @PaymentID";

            await _dbConnection.ExecuteAsync(query, payment);
        }

        public async Task DeleteAsync(Guid paymentId)
        {
            var query = "DELETE FROM dbo.[Payment] WHERE PaymentID = @PaymentID";
            await _dbConnection.ExecuteAsync(query, new { PaymentID = paymentId });
        }
    }
}
