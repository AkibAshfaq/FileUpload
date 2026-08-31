using Dapper;
using FileUpload.Repository.Database;
using FileUpload.Repository.Entities;
using FileUpload.Repository.Repositories.Abstractions;

namespace FileUpload.Repository.Repositories
{
    public class PhotoRepository : IFileUploadRepository<PhotoEntity>
    {
        private readonly ISqlConnectionFactory _connectionFactory;

        public PhotoRepository(ISqlConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<long> InsertAsync(PhotoEntity entity)
        {
            const string sql = @"
                INSERT INTO dbo.Photos (EmployeeId, FileName, ContentType, SizeBytes, Content, UploadedAtUtc)
                OUTPUT INSERTED.Id
                VALUES (@EmployeeId, @FileName, @ContentType, @SizeBytes, @Content, @UploadedAtUtc);";

            using var connection = _connectionFactory.CreateConnection();
            return await connection.ExecuteScalarAsync<long>(sql, entity);
        }

        public async Task<PhotoEntity?> GetByIdAsync(long id)
        {
            const string sql = "SELECT * FROM dbo.Photos WHERE Id = @Id;";

            using var connection = _connectionFactory.CreateConnection();
            return await connection.QuerySingleOrDefaultAsync<PhotoEntity>(sql, new { Id = id });
        }

        public async Task<bool> UpdateAsync(PhotoEntity entity)
        {
            const string sql = @"
                UPDATE dbo.Photos
                SET FileName = @FileName, ContentType = @ContentType, SizeBytes = @SizeBytes, Content = @Content
                WHERE Id = @Id;";

            using var connection = _connectionFactory.CreateConnection();
            var rowsAffected = await connection.ExecuteAsync(sql, entity);
            return rowsAffected > 0;
        }

        public async Task<bool> DeleteAsync(long id)
        {
            const string sql = "DELETE FROM dbo.Photos WHERE Id = @Id;";

            using var connection = _connectionFactory.CreateConnection();
            var rowsAffected = await connection.ExecuteAsync(sql, new { Id = id });
            return rowsAffected > 0;
        }

        public async Task<IReadOnlyList<PhotoEntity>> GetAllAsync()
        {
            const string sql = "SELECT * FROM dbo.Photos;";

            using var connection = _connectionFactory.CreateConnection();
            var results = await connection.QueryAsync<PhotoEntity>(sql);
            return results.ToList();
        }

        public async Task<IReadOnlyList<PhotoEntity>> QueryAsync(Func<PhotoEntity, bool> predicate)
        {
            var all = await GetAllAsync();
            return all.Where(predicate).ToList();
        }
    }
}
