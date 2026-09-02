using FileUpload.AggregateRoot.FluentValidation;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace FileUpload.AggregateRoot.Dependency
{
    public static class Dependency
    {
        public static IServiceCollection AddDependency(this IServiceCollection services)
        {
            services.AddScoped<FileUploadAggregate>();
            services.AddValidatorsFromAssembly(typeof(CreateOrUpdateValidator).Assembly);
            return services;
        }
    }
}
