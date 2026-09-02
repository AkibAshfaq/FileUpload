namespace ERS.Shared.Abstractions.QueryHandler
{
    public interface IQueryHandler<TQuery, TResult>
    {
        Task<IEnumerable<TResult>> HandleAsync(TQuery query);
    }
}
