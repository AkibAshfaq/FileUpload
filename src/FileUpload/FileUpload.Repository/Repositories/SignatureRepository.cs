using Dapper;
using FileUpload.Repository.Database;
using FileUpload.Repository.Entities;
using FileUpload.Repository.Repositories.Abstractions;

namespace FileUpload.Repository.Repositories
{
    public class SignatureRepository : IFileUploadRepository<SignatureEntity>
    {
        private readonly ISqlConnectionFactory _connectionFactory;

        public SignatureRepository(ISqlConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<long> InsertAsync(SignatureEntity entity)
        {
            const string sql = @"
                INSERT INTO dbo.Signatures (EmployeeId, FileName, ContentType, SizeBytes, Content, UploadedAtUtc)
                OUTPUT INSERTED.Id
                VALUES (@EmployeeId, @FileName, @ContentType, @SizeBytes, @Content, @UploadedAtUtc);";

            using var connection = _connectionFactory.CreateConnection();
            return await connection.ExecuteScalarAsync<long>(sql, entity);
        }

        public async Task<SignatureEntity?> GetByIdAsync(long id)
        {
            const string sql = "SELECT * FROM dbo.Signatures WHERE Id = @Id;";

            using var connection = _connectionFactory.CreateConnection();
            return await connection.QuerySingleOrDefaultAsync<SignatureEntity>(sql, new { Id = id });
        }

        public async Task<bool> UpdateAsync(SignatureEntity entity)
        {
            const string sql = @"
                UPDATE dbo.Signatures
                SET FileName = @FileName, ContentType = @ContentType, SizeBytes = @SizeBytes, Content = @Content
                WHERE Id = @Id;";

            using var connection = _connectionFactory.CreateConnection();
            var rowsAffected = await connection.ExecuteAsync(sql, entity);
            return rowsAffected > 0;
        }

        public async Task<bool> DeleteAsync(long id)
        {
            const string sql = "DELETE FROM dbo.Signatures WHERE Id = @Id;";

            using var connection = _connectionFactory.CreateConnection();
            var rowsAffected = await connection.ExecuteAsync(sql, new { Id = id });
            return rowsAffected > 0;
        }

        public async Task<IReadOnlyList<SignatureEntity>> GetAllAsync()
        {
            const string sql = "SELECT * FROM dbo.Signatures;";

            using var connection = _connectionFactory.CreateConnection();
            var results = await connection.QueryAsync<SignatureEntity>(sql);
            return results.ToList();
        }

        public async Task<IReadOnlyList<SignatureEntity>> QueryAsync(Func<SignatureEntity, bool> predicate)
        {
            var all = await GetAllAsync();
            return all.Where(predicate).ToList();
        }
    }
}
