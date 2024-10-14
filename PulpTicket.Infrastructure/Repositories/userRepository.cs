using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Dapper;
using PulpTicket.Domain.Entities;
using PulpTicket.Infrastructure.DbContext;
using PulpTicket.Application.Interfaces;


namespace PulpTicket.Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    private readonly DapperDbContext _dbContext;

    public UserRepository(DapperDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<User>> GetAllUsersAsync()
    {
        using (var connection = _dbContext.GetConnection())
        {
            var sql = "SELECT * FROM Users";
            return await connection.QueryAsync<User>(sql);
        }
    }

    public async Task<User> GetUserByIdAsync(Guid id)
    {
        using (var connection = _dbContext.GetConnection())
        {
            var sql = "SELECT * FROM Users WHERE Id = @Id";
            return await connection.QuerySingleOrDefaultAsync<User>(sql, new { Id = id });
        }
    }

    public async Task AddUserAsync(User user)
    {
        using (var connection = _dbContext.GetConnection())
        {
            var sql = "INSERT INTO Users (Id, Name, Email, Phone, CreatedAt) VALUES (@Id, @Name, @Email, @Phone, @CreatedAt)";
            await connection.ExecuteAsync(sql, user);
        }
    }

    public async Task UpdateUserAsync(User user)
    {
        using (var connection = _dbContext.GetConnection())
        {
            var sql = "UPDATE Users SET Name = @Name, Email = @Email, Phone = @Phone, UpdatedAt = @UpdatedAt WHERE Id = @Id";
            await connection.ExecuteAsync(sql, user);
        }
    }

    public async Task DeleteUserAsync(Guid id)
    {
        using (var connection = _dbContext.GetConnection())
        {
            var sql = "DELETE FROM Users WHERE Id = @Id";
            await connection.ExecuteAsync(sql, new { Id = id });
        }
    }
}
