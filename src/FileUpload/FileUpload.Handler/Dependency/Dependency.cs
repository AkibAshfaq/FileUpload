using FileUpload.AggregateRoot.Dependency;
using FileUpload.DTO.Dependency;
using FileUpload.Repository.Dependency;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FileUpload.Handler.Dependency
{
    public static class Dependency
    {
        public static IServiceCollection AddHandlerDependency(this IServiceCollection services, IConfiguration config)
        {
            services.AddDTODependency();
            services.AddRepositoryDependency(config);
            services.AddDependency();
            return services;
        }
    }
}
