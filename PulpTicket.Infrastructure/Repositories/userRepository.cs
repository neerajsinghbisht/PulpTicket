using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Dapper;
using PulpTicket.Domain.Entities;
using PulpTicket.Domain.Repositories;

namespace PulpTicket.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IDbConnection _dbConnection;

        public UserRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<User> GetByIdAsync(Guid id)
        {
            var query = "SELECT * FROM [User] WHERE Id = @Id";
            return await _dbConnection.QueryFirstOrDefaultAsync<User>(query, new { Id = id });
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            var query = "SELECT * FROM [User]";
            return await _dbConnection.QueryAsync<User>(query);
        }

        public async Task AddAsync(User entity)
        {
            var existingUser = await GetByIdAsync(entity.Id);
            if (existingUser != null)
            {
                // Generate a new ID if a duplicate is found
                entity.Id = Guid.NewGuid();
            }
            var query = "INSERT INTO [User] (Id, Name, Email, Phone,Address_Id,Password,UpdatedAt,CreatedAt,CreatedBy,UpdatedBy,IsActive,IsDeleted) VALUES (@Id, @Name, @Email,@phone,@Address_Id,@Password,@UpdatedAt,@CreatedAt,@CreatedBy,@UpdatedBy,@IsActive,@IsDeleted)";
            await _dbConnection.ExecuteAsync(query, entity);
        }

        public async Task UpdateAsync(User entity)
        {
            var query = "UPDATE [User] SET Name = @Name, Email = @Email, Phone=@Phone WHERE Id = @Id";
            await _dbConnection.ExecuteAsync(query, entity);
        }

        public async Task DeleteAsync(Guid id)
        {
            var query = "DELETE FROM dbo.[User] WHERE Id = @Id";
            await _dbConnection.ExecuteAsync(query, new { Id = id });
        }
    }
}
