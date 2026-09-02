using Microsoft.Extensions.DependencyInjection;

namespace ServiceBus.Dependency
{
    public static class Dependency
    {
        public static IServiceCollection AddDependency(this IServiceCollection services)
        {
            services.AddScoped<IServiceBus, ServiceBus>();
            return services;
        }
    }
}
