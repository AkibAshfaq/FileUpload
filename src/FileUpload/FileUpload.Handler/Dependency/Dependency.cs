using ERS.Shared.Abstractions.CommandHandler;
using ERS.Shared.Abstractions.QueryHandler;
using FileUpload.AggregateRoot.Dependency;
using FileUpload.DTO.Commands.CertificateCommands;
using FileUpload.DTO.Commands.PhotoCommands;
using FileUpload.DTO.Commands.SignatureCommands;
using FileUpload.DTO.Dependency;
using FileUpload.DTO.Queries;
using FileUpload.DTO.Results;
using FileUpload.Handler.CommandHandlers.CertificateHandlers;
using FileUpload.Handler.CommandHandlers.PhotoHandlers;
using FileUpload.Handler.CommandHandlers.SignatureHandlers;
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
            services.AddDTODependency();
            services.AddRepositoryDependency(config);
            services.AddDependency();

            services.AddScoped<ICommandHandler<CreateOrUpdatePhotoCommand>, CreatePhotoHandler>();
            services.AddScoped<ICommandHandler<DeletePhotoCommand>, DeletePhotoHandler>();
            services.AddScoped<IQueryHandler<GetPhotoContentQuery, PhotoContentResponse>, GetPhotoHandler>();

            services.AddScoped<ICommandHandler<CreateOrUpdateCertificateCommand>, CreateOrUpdateCertificateHandler>();
            services.AddScoped<ICommandHandler<DeleteCertificateCommand>, DeleteCertificateHandler>();
            services.AddScoped<IQueryHandler<GetCretificateContentQuery, CertificateContentResponse>, GetCertificateHandler>();

            services.AddScoped<ICommandHandler<CreateOrUpdateSignatureCommand>, CreateSignatureHandler>();
            services.AddScoped<ICommandHandler<DeleteSignatureCommand>, DeleteSignatureHandler>();
            services.AddScoped<IQueryHandler<GetSignatureContentQuery, SignatureContentResponse>, GetSignatureHandler>();

            return services;
        }
    }
}
