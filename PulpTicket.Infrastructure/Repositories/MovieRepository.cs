using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Dapper;
using PulpTicket.Infrastructure.DbContext;
using PulpTicket.Application.Interfaces;
using PulpTicket.Domain.Entities;

namespace XMP.Infrastructure.Repositories
{
    public class MovieRepository : IMovieRepository
    {
        private readonly DapperDbContext _dbContext;

        public MovieRepository(DapperDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Movie>> GetAllMoviesAsync()
        {
            using (var connection = _dbContext.GetConnection())
            {
                var sql = "SELECT * FROM Movies WHERE IsDeleted = 0";
                return await connection.QueryAsync<Movie>(sql);
            }
        }

        public async Task<Movie> GetMovieByIdAsync(Guid id)
        {
            using (var connection = _dbContext.GetConnection())
            {
                var sql = "SELECT * FROM Movies WHERE Movie_Id = @Id AND IsDeleted = 0";
                return await connection.QuerySingleOrDefaultAsync<Movie>(sql, new { Id = id });
            }
        }

        public async Task AddMovieAsync(Movie movie)
        {
            using (var connection = _dbContext.GetConnection())
            {
                var sql = @"INSERT INTO Movies (Movie_Id, Name, Language, Genre, Cast, Image, CreatedAt, CreatedBy, IsActive, IsDeleted)
                            VALUES (@Movie_Id, @Name, @Language, @Genre, @Cast, @Image, @CreatedAt, @CreatedBy, @IsActive, @IsDeleted)";
                await connection.ExecuteAsync(sql, movie);
            }
        }

        public async Task UpdateMovieAsync(Movie movie)
        {
            using (var connection = _dbContext.GetConnection())
            {
                var sql = @"UPDATE Movies SET 
                            Name = @Name, 
                            Language = @Language, 
                            Genre = @Genre, 
                            Cast = @Cast, 
                            Image = @Image, 
                            UpdatedAt = @UpdatedAt,
                            UpdatedBy = @UpdatedBy,
                            IsActive = @IsActive,
                            IsDeleted = @IsDeleted
                            WHERE Movie_Id = @Movie_Id";
                await connection.ExecuteAsync(sql, movie);
            }
        }

        public async Task DeleteMovieAsync(Guid id)
        {
            using (var connection = _dbContext.GetConnection())
            {
                var sql = "UPDATE Movies SET IsDeleted = 1 WHERE Movie_Id = @Id";
                await connection.ExecuteAsync(sql, new { Id = id });
            }
        }
    }
}
