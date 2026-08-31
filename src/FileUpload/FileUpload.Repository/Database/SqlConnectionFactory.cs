using System.Data;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace FileUpload.Repository.Database
{
    public sealed class SqlConnectionFactory : ISqlConnectionFactory
    {
        private readonly string _connectionString;

        public SqlConnectionFactory(IConfiguration config)
        {
            _connectionString = config.GetConnectionString("FileUploadDb")
                ?? throw new InvalidOperationException("Connection string 'FileUploadDb' is not configured.");
        }

        public IDbConnection CreateConnection() => new SqlConnection(_connectionString);
    }
}
