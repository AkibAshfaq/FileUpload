using ERS.Shared;
using ERS.Shared.Abstractions.Command;
using ERS.Shared.Abstractions.CommandHandler;
using ERS.Shared.Abstractions.Query;
using ERS.Shared.Abstractions.QueryHandler;
using ERS.Shared.Abstractions.Result;
using Microsoft.Extensions.DependencyInjection;

namespace ServiceBus
{
    public class ServiceBus : IServiceBus
    {
        private readonly IServiceProvider _services;
        public ServiceBus(IServiceProvider services)
        {
            _services = services;
        }
        public Task<IEnumerable<Event>> SendCommandAsync<TCommand>(TCommand command) where TCommand : ICommand
        {
            var handler = _services.GetRequiredService<ICommandHandler<TCommand>>();
            return handler.HandleAsync(command);
        }

        public Task<IEnumerable<TResult>> SendQueryAsync<TQuery, TResult>(TQuery query) where TQuery : IQuery<IResult>
        {
            var handler = _services.GetRequiredService<IQueryHandler<TQuery, TResult>>();
            return handler.HandleAsync(query);    
        }
    }
}
