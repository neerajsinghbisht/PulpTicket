using PulpTicket.Domain.Entities;
using PulpTicket.Domain.Repositories;
using System.Data;
using Dapper;
using System.Data.Common;


namespace PulpTicket.Infrastructure.Repositories
{
    public class AddressRepository : IAddressRepository
    {

        private readonly IDbConnection _dbconnection;
        public AddressRepository(IDbConnection dbConnection)
        {

            _dbconnection = dbConnection;

        }
        public async Task<Address> GetByIdAsync(Guid Address_id)
        {
            var query = "SELECT * FROM dbo.[Address] WHERE Address_id = @Address_id";
            return await _dbconnection.QueryFirstOrDefaultAsync<Address>(query, new { Address_id = Address_id });
        }

        public async Task<IEnumerable<Address>> GetAllAsync()
        {
            var query = "SELECT * FROM dbo.[Address]";
            return await _dbconnection.QueryAsync<Address>(query);
        }

        public async Task AddAsync(Address entity)
        {
            var existingUser = await GetByIdAsync(entity.Address_Id);
            if (existingUser != null)
            {
                // Generate a new ID if a duplicate is found
                entity.Address_Id = Guid.NewGuid();
            }
            var query = "INSERT INTO [Address] (Address_Id,Street_Address, City,state, Zipcode,CreatedAt, UpdatedAt, CreatedBy, UpdatedBy, IsActive, IsDeleted) VALUES (@Address_Id,@Street_Address,@city,@state,@Zipcode, GETDATE(), NULL, @CreatedBy, @UpdatedBy, @IsActive, @IsDeleted)";
            await _dbconnection.ExecuteAsync(query, entity);
        }

        public async Task UpdateAsync(Address entity)
        {
            // Check and assign current date if DateTime.MinValue is detected
            entity.CreatedAt = (entity.CreatedAt == DateTime.MinValue) ? DateTime.Now : entity.CreatedAt;
            entity.UpdatedAt = (entity.UpdatedAt == DateTime.MinValue) ? DateTime.Now : entity.UpdatedAt;

            var query = @"
    UPDATE dbo.[Address]
    SET Street_Address = @Street_Address, 
        City = @City, 
        State = @State, 
        Zipcode = @Zipcode, 
        CreatedAt = @CreatedAt, 
        UpdatedAt = @UpdatedAt, 
        CreatedBy = @CreatedBy, 
        UpdatedBy = @UpdatedBy, 
        IsActive = @IsActive, 
        IsDeleted = @IsDeleted
    WHERE Address_Id = @Address_Id";
            

            await _dbconnection.ExecuteAsync(query, entity);
        }

        public async Task DeleteAsync(Guid Address_id)
        {
            var query = "DELETE FROM dbo.[Address] WHERE Address_Id = @Address_Id";
            await _dbconnection.ExecuteAsync(query, new { Address_Id = Address_id });
        }

    }
}
