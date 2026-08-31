
namespace FileUpload.Repository.Repositories.Abstractions
{
    public interface IFileUploadRepository<T> where T : class
    {
        Task<long> InsertAsync(T entity);
        Task<T?> GetByIdAsync(long id);
        Task<bool> UpdateAsync(T entity);
        Task<bool> DeleteAsync(long id);
        Task<IReadOnlyList<T>> GetAllAsync();
        Task<IReadOnlyList<T>> QueryAsync(Func<T, bool> predicate);
    }
}
