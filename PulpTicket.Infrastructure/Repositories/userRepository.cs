
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
            var query = @"
        SELECT 
            u.Id, u.Name, u.Email, u.Phone, u.Address_Id, u.CreatedAt, u.UpdatedAt, u.CreatedBy, u.UpdatedBy, u.IsActive, u.IsDeleted, u.Password,
            a.Address_Id, a.Street_Address, a.City, a.State, a.Zipcode
        FROM [User] u
        LEFT JOIN [Address] a ON u.Address_Id = a.Address_Id";

            var userDictionary = new Dictionary<Guid, User>();

            var result = await _dbConnection.QueryAsync<User, Address, User>(
                query,
                (user, address) =>
                {
                    if (!userDictionary.TryGetValue(user.Id, out var currentUser))
                    {
                        currentUser = user;
                        userDictionary.Add(user.Id, currentUser);
                    }

                    currentUser.Address = address; // Assign the Address object to the User
                    return currentUser;
                },
                splitOn: "Address_Id"
            );

            return userDictionary.Values;
        }

        public async Task AddAsync(User entity)
        { 
                entity.Id= Guid.NewGuid();
                entity.Address.Address_Id= Guid.NewGuid();
            entity.Address_Id = entity.Address.Address_Id;

            var userQuery = @"INSERT INTO [User] 
                        (Id, Name, Email, Phone, Address_Id, Password, UpdatedAt, CreatedAt, CreatedBy, UpdatedBy, IsActive, IsDeleted) 
                      VALUES 
                        (@Id, @Name, @Email, @Phone, @Address_Id, @Password, @UpdatedAt, @CreatedAt, @CreatedBy, @UpdatedBy, @IsActive, @IsDeleted)";

            var addressQuery = @"INSERT INTO [Address] 
                          (Address_Id, Street_Address, City, State, Zipcode) 
                         VALUES 
                          (@Address_Id, @Street_Address, @City, @State, @Zipcode)";

            // Open the connection if it’s not already open
            if (_dbConnection.State == System.Data.ConnectionState.Closed)
            {
                _dbConnection.Open(); // Use synchronous Open() method
            }

            using (var transaction = _dbConnection.BeginTransaction())
            {
                try
                {
                    // Insert Address data
                    await _dbConnection.ExecuteAsync(addressQuery, new
                    {
                        Address_Id = entity.Address.Address_Id,
                        Street_Address = entity.Address.Street_Address,
                        City = entity.Address.City,
                        State = entity.Address.State,
                        Zipcode = entity.Address.Zipcode
                    }, transaction);

                    // Insert User data
                    await _dbConnection.ExecuteAsync(userQuery, entity, transaction);

                    transaction.Commit();
                }
                catch
                {
                    transaction.Rollback();
                    throw;
                }
                finally
                {
                    // Close the connection to release resources
                    _dbConnection.Close(); // Use synchronous Close() method
                }
            }
        }


        public async Task UpdateAsync(User entity)
        {

            entity.UpdatedAt = DateTime.Now;
            // Define SQL update queries for User and Address
            var userQuery = "UPDATE [User] SET Name = @Name, Email = @Email, Phone = @Phone WHERE Id = @Id";
            var addressQuery = "UPDATE [Address] SET Street_Address = @Street_Address, City = @City, State = @State, Zipcode = @Zipcode WHERE Address_Id = @Address_Id";

            

         
                
                    // Update User data using mapped properties
                    await _dbConnection.ExecuteAsync(userQuery, entity);

                    // Update Address data using mapped properties
                    await _dbConnection.ExecuteAsync(addressQuery, entity.Address);

                  
            
        }

        public async Task DeleteAsync(Guid id)
        {
            var query = "DELETE FROM dbo.[User] WHERE Id = @Id";
            await _dbConnection.ExecuteAsync(query, new { Id = id });
        }
    }
}
