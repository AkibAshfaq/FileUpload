using Microsoft.Extensions.DependencyInjection;

namespace FileUpload.AggregateRoot.Dependency
{
    public static class Dependency
    {
        public static IServiceCollection AddDependency(this IServiceCollection services)
        {
            return services;
        }
    }
}
