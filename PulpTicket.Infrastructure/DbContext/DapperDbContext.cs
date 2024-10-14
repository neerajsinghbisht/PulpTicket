using System;
using System.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Data.SqlClient; // SQL Server-specific connection


namespace PulpTicket.Infrastructure.DbContext
{
    public class DapperDbContext : IDisposable
    {
        private readonly IDbConnection _connection;

        public DapperDbContext(IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DbConnection");
            _connection = new SqlConnection(connectionString);
        }

        public IDbConnection GetConnection()
        {
            if (_connection.State != ConnectionState.Open)
            {
                _connection.Open();
            }
            return _connection;
        }

        public void Dispose()
        {
            if (_connection.State != ConnectionState.Closed)
            {
                _connection.Close();
            }
            _connection.Dispose();
        }
    }
}
