using FileUpload.AggregateRoot;
using FileUpload.Repository.ConnectionFactory;
using FileUpload.Repository.Repositories;
using FileUpload.Repository.Repositories.Abstractions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FileUpload.Repository.Dependency
{
    public static class Dependencyinject
    {
        public static IServiceCollection AddRepositoryDependency(this IServiceCollection services, IConfiguration config)
        {
            services.AddScoped<IFileUploadRepository<FileUploadAggregate>, FileUploadRepository>();
            services.AddScoped<ISqlConnectionFactory, SqlConnectionFactory>();
            return services;
        }
    }
}
