using ERS.Shared;
using ERS.Shared.Abstractions.Command;
using ERS.Shared.Abstractions.Query;
using ERS.Shared.Abstractions.Result;

namespace ServiceBus
{
    public interface IServiceBus
    {
        public Task<IEnumerable<Event>> SendCommandAsync<TCommand>(TCommand command) where TCommand : ICommand;
        public Task<IEnumerable<TResult>> SendQueryAsync<TQuery, TResult>(TQuery query) where TQuery : IQuery<IResult>;
    }
}
