using Dapper;
using Microsoft.AspNetCore.Http.HttpResults;
using PulpTicket.Domain.Entities;
using PulpTicket.Domain.Repositories;

using System.Data;
using System.Data.Common;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using static Dapper.SqlMapper;


namespace PulpTicket.Infrastructure.Repositories
{
    public class MovieRepository : IMovieRepository
    {

        private readonly IDbConnection _dbConnection;

        public MovieRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<Movie> GetByIdAsync(Guid Movie_Id)
        {
            
            var query = "SELECT * from [Movies] WHERE Movie_Id =@Movie_Id";
            
            var movie= await _dbConnection.QueryFirstOrDefaultAsync<Movie>(query, new { Movie_Id = Movie_Id });
            if (movie == null || movie.IsDeleted)
                return null;

            return movie;





        }


        public async Task<IEnumerable<Movie>> GetAllAsync(string? filterOn = null, string? filterQuery = null, string? sortBy = "Name",
    bool isDescending = false, int pageNumber = 1, int pageSize = 1000)
        {
            // Define a list of allowed columns to filter on
            var allowedColumns = new List<string> { "Name", "Genre", "Language", "Cast" }; // Example columns

            var sortColumn = allowedColumns.Contains(sortBy, StringComparer.OrdinalIgnoreCase) ? sortBy : "Name";

            // Base query to get all movies
            var query = "SELECT * FROM [Movies]";
            var parameters = new DynamicParameters();

            // Check if filtering is requested and if filterOn is a valid column
            if (!string.IsNullOrEmpty(filterOn) && allowedColumns.Contains(filterOn, StringComparer.OrdinalIgnoreCase) && !string.IsNullOrEmpty(filterQuery))
            {
                query += $" WHERE [{filterOn}] LIKE @FilterQuery";  // Add the column name safely
                parameters.Add("FilterQuery", $"%{filterQuery}%");
            }

            // Adding pagination
            var sortDirection = isDescending ? "DESC" : "ASC";
    query += $" ORDER BY [{sortColumn}] {sortDirection} OFFSET @Offset ROWS FETCH NEXT @PageSize ROWS ONLY";
    parameters.Add("Offset", (pageNumber - 1) * pageSize);
    parameters.Add("PageSize", pageSize);


            // Execute the query with the filter and pagination applied
            return await _dbConnection.QueryAsync<Movie>(query, parameters);
        }

        public async Task AddAsync(Movie entity)
        {
            var Id = await GetByIdAsync(entity.Movie_Id);
            if (Id != null)
            {
                entity.Movie_Id = Guid.NewGuid();
                entity.IsDeleted = false;
            }
            var query = "INSERT INTO [Movies] (Movie_Id, Name, Language, Genre, Cast, CreatedAt, UpdatedAt, CreatedBy, UpdatedBy, IsActive, IsDeleted) VALUES  (@Movie_Id, @Name, @Language, @Genre, @Cast, GETDATE(), NULL, @Movie_Id, @UpdatedBy, @IsActive, @IsDeleted)";
                await _dbConnection.ExecuteAsync(query, entity);
        }



        public async Task DeleteAsync(Guid Movie_Id)
        {
            var query = "UPDATE dbo.[Movies] SET IsDeleted = 1 WHERE Movie_Id = @Movie_Id";

            await _dbConnection.ExecuteAsync(query, new { movie_Id = Movie_Id });
        }


    }
}






