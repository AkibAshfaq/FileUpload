namespace ERS.Shared.Abstractions.CommandHandler
{
    public interface ICommandHandler<TCommand>
    {
        Task<IEnumerable<Event>> HandleAsync(TCommand command);
    }
}
