using FileUpload.Repository.Database;
using FileUpload.Repository.Entities;
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
            services.AddSingleton<ISqlConnectionFactory, SqlConnectionFactory>();

            services.AddScoped<IFileUploadRepository<PhotoEntity>, PhotoRepository>();
            services.AddScoped<IFileUploadRepository<CertificateEntity>, CertificateRepository>();
            services.AddScoped<IFileUploadRepository<SignatureEntity>, SignatureRepository>();

            return services;
        }
    }
}
