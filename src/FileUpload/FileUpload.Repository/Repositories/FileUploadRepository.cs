using Dapper;
using FileUpload.AggregateRoot;
using FileUpload.Repository.ConnectionFactory;
using FileUpload.Repository.Repositories.Abstractions;

namespace FileUpload.Repository.Repositories
{
    public class FileUploadRepository : IFileUploadRepository<FileUploadAggregate>
    {
        private readonly ISqlConnectionFactory _connectionfactory;
        public FileUploadRepository(ISqlConnectionFactory connectionfactory)
        {
            _connectionfactory = connectionfactory;
        }
        public async Task<bool> DeleteAsync(long id, string filetype)
        {
            const string sql = "DELETE FROM UploadedFiles WHERE BdjobsId = @Id AND FileType = @FileType";
            
            var connection = _connectionfactory.CreateConnectionAsync();
            var rowaffected = await connection.ExecuteAsync(sql, new { id, filetype });
            return rowaffected > 0;
        }
        public async Task<IReadOnlyList<FileUploadAggregate>> GetAllAsync()
        {
            const string sql = "SELECT * FROM UploadedFiles";
            
            var connection = _connectionfactory.CreateConnectionAsync();
            var result = await connection.QueryAsync<FileUploadAggregate>(sql);
            return result.ToList();
        }
        public async Task<FileUploadAggregate> GetByIdAsync(long id, string filetype)
        {
            const string sql = "SELECT * FROM UploadedFiles WHERE BdjobsId = @Id AND FileType = @FileType";
            var connection = _connectionfactory.CreateConnectionAsync();
            var result = await connection.QueryFirstOrDefaultAsync<FileUploadAggregate>(sql, new { id, filetype });
            return result;
        }
        public async Task<long> InsertAsync(FileUploadAggregate entity)
        {
            const string sql = @"INSERT INTO UploadedFiles (BdjobsId, FileName, FileType, ContentType, SizeBytes, FileData, CreatedAtUtc)
                    VALUES (@BdjobsId, @FileName, @FileType, @ContentType, @SizeBytes, @FileData, @CreatedAt);";
            var connection = _connectionfactory.CreateConnectionAsync();
            var result = await connection.QueryFirstOrDefaultAsync<long>(sql, entity);
            return result;
        }
        public async Task<IReadOnlyList<FileUploadAggregate>> QueryAsync(Func<FileUploadAggregate, bool> predicate)
        {
            var allFiles = await GetAllAsync();
            return allFiles.Where(predicate).ToList();
        }
        public async Task<bool> UpdateAsync(FileUploadAggregate entity)
        {
            const string sql = "UPDATE UploadedFiles SET FileName = @FileName, SizeBytes = @SizeBytes, ContentType = @ContentType, FileType = @Filetype, FileData = @FileData, UpdatedAtUtc = @UpdatedAt WHERE BdjobsId = @BdjobsId";
            var connection = _connectionfactory.CreateConnectionAsync();
            var rowaffected = await connection.ExecuteAsync(sql, entity);
            return rowaffected > 0;
        }
    }
}
