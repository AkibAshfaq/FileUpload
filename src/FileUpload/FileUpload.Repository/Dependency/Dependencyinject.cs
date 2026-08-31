using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FileUpload.Repository.Dependency
{
    public static class Dependencyinject
    {
        public static IServiceCollection AddRepositoryDependency(this IServiceCollection services, IConfiguration config)
        {
            return services;
        }
    }
}
