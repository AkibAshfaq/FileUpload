using FileUpload.DTO.Commands;
using FileUpload.DTO.Queries;
using FileUpload.DTO.Results;
using Microsoft.Extensions.DependencyInjection;

namespace FileUpload.DTO.Dependency
{
    public static class Dependency
    {
        public static IServiceCollection AddDTODependency(this IServiceCollection services)
        {
            services.AddScoped<CreateOrUpdateContentCommand>();
            services.AddScoped<DeleteContentCommand>();
            services.AddScoped<GetContentQuery>();
            services.AddScoped<ContentResponse>();
            return services;
        }
    }
}
