using ERS.Shared;
using ERS.Shared.Abstractions.CommandHandler;
using FileUpload.DTO.Commands.CertificateCommands;
using FileUpload.Handler.Events;
using FileUpload.Repository.Entities;
using FileUpload.Repository.Repositories.Abstractions;

namespace FileUpload.Handler.CommandHandlers.CertificateHandlers
{
    public class CreateOrUpdateCertificateHandler : ICommandHandler<CreateOrUpdateCertificateCommand>
    {
        private readonly IFileUploadRepository<CertificateEntity> _repository;

        public CreateOrUpdateCertificateHandler(IFileUploadRepository<CertificateEntity> repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Event>> HandleAsync(CreateOrUpdateCertificateCommand command)
        {
            using var memoryStream = new MemoryStream();
            await command.Content.CopyToAsync(memoryStream);

            var entity = new CertificateEntity
            {
                EmployeeId = command.EmployeeId,
                Title = command.Title,
                IssuedBy = command.IssuedBy,
                IssuedOn = command.IssuedOn?.ToDateTime(TimeOnly.MinValue),
                ExpiresOn = command.ExpiresOn?.ToDateTime(TimeOnly.MinValue),
                FileName = command.FileName,
                ContentType = command.ContentType,
                SizeBytes = command.Length,
                Content = memoryStream.ToArray(),
                UploadedAtUtc = DateTime.UtcNow
            };

            var id = await _repository.InsertAsync(entity);

            return [new FileUploadedEvent { Id = id }];
        }
    }
}
