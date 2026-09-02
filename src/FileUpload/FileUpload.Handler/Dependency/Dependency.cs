using ERS.Shared.Abstractions.CommandHandler;
using ERS.Shared.Abstractions.QueryHandler;
using FileUpload.AggregateRoot.Dependency;
using FileUpload.DTO.Commands;
using FileUpload.DTO.Dependency;
using FileUpload.DTO.Queries;
using FileUpload.DTO.Results;
using FileUpload.Handler.CommandHandlers;
using FileUpload.Handler.QueryHandlers;
using FileUpload.Repository.Dependency;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FileUpload.Handler.Dependency
{
    public static class Dependency
    {
        public static IServiceCollection AddHandlerDependency(this IServiceCollection services, IConfiguration config)
        {
            services.AddScoped<ICommandHandler<CreateOrUpdateContentCommand>, CreateOrUpdateContentHandler>();
            services.AddScoped<ICommandHandler<DeleteContentCommand>, DeleteContentHandler>();
            services.AddScoped<IQueryHandler<GetContentQuery, ContentResponse>, GetContentHandler>();
            services.AddDTODependency();
            services.AddRepositoryDependency(config);
            services.AddDependency();
            return services;
        }
    }
}
