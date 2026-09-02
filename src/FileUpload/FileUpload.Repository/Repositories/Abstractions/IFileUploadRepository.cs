
namespace FileUpload.Repository.Repositories.Abstractions
{
    public interface IFileUploadRepository<FileUploadAggregate>
    {
        Task<long> InsertAsync(FileUploadAggregate entity);
        Task<FileUploadAggregate> GetByIdAsync(long id);
        Task<bool> UpdateAsync(FileUploadAggregate entity);
        Task<bool> DeleteAsync(long id);
        Task<IReadOnlyList<FileUploadAggregate>> GetAllAsync();
        Task<IReadOnlyList<FileUploadAggregate>> QueryAsync(Func<FileUploadAggregate, bool> predicate);
    }
}
