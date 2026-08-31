using Dapper;
using FileUpload.Repository.Database;
using FileUpload.Repository.Entities;
using FileUpload.Repository.Repositories.Abstractions;

namespace FileUpload.Repository.Repositories
{
    public class CertificateRepository : IFileUploadRepository<CertificateEntity>
    {
        private readonly ISqlConnectionFactory _connectionFactory;

        public CertificateRepository(ISqlConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<long> InsertAsync(CertificateEntity entity)
        {
            const string sql = @"
                INSERT INTO dbo.Certificates (EmployeeId, Title, IssuedBy, IssuedOn, ExpiresOn, FileName, ContentType, SizeBytes, Content, UploadedAtUtc)
                OUTPUT INSERTED.Id
                VALUES (@EmployeeId, @Title, @IssuedBy, @IssuedOn, @ExpiresOn, @FileName, @ContentType, @SizeBytes, @Content, @UploadedAtUtc);";

            using var connection = _connectionFactory.CreateConnection();
            return await connection.ExecuteScalarAsync<long>(sql, entity);
        }

        public async Task<CertificateEntity?> GetByIdAsync(long id)
        {
            const string sql = "SELECT * FROM dbo.Certificates WHERE Id = @Id;";

            using var connection = _connectionFactory.CreateConnection();
            return await connection.QuerySingleOrDefaultAsync<CertificateEntity>(sql, new { Id = id });
        }

        public async Task<bool> UpdateAsync(CertificateEntity entity)
        {
            const string sql = @"
                UPDATE dbo.Certificates
                SET Title = @Title, IssuedBy = @IssuedBy, IssuedOn = @IssuedOn, ExpiresOn = @ExpiresOn,
                    FileName = @FileName, ContentType = @ContentType, SizeBytes = @SizeBytes, Content = @Content
                WHERE Id = @Id;";

            using var connection = _connectionFactory.CreateConnection();
            var rowsAffected = await connection.ExecuteAsync(sql, entity);
            return rowsAffected > 0;
        }

        public async Task<bool> DeleteAsync(long id)
        {
            const string sql = "DELETE FROM dbo.Certificates WHERE Id = @Id;";

            using var connection = _connectionFactory.CreateConnection();
            var rowsAffected = await connection.ExecuteAsync(sql, new { Id = id });
            return rowsAffected > 0;
        }

        public async Task<IReadOnlyList<CertificateEntity>> GetAllAsync()
        {
            const string sql = "SELECT * FROM dbo.Certificates;";

            using var connection = _connectionFactory.CreateConnection();
            var results = await connection.QueryAsync<CertificateEntity>(sql);
            return results.ToList();
        }

        public async Task<IReadOnlyList<CertificateEntity>> QueryAsync(Func<CertificateEntity, bool> predicate)
        {
            var all = await GetAllAsync();
            return all.Where(predicate).ToList();
        }
    }
}
