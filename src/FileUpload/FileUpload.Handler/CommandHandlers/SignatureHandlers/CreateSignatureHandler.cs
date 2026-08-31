using ERS.Shared;
using ERS.Shared.Abstractions.CommandHandler;
using FileUpload.DTO.Commands.SignatureCommands;
using FileUpload.Handler.Events;
using FileUpload.Repository.Entities;
using FileUpload.Repository.Repositories.Abstractions;

namespace FileUpload.Handler.CommandHandlers.SignatureHandlers
{
    public class CreateSignatureHandler : ICommandHandler<CreateOrUpdateSignatureCommand>
    {
        private readonly IFileUploadRepository<SignatureEntity> _repository;

        public CreateSignatureHandler(IFileUploadRepository<SignatureEntity> repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Event>> HandleAsync(CreateOrUpdateSignatureCommand command)
        {
            using var memoryStream = new MemoryStream();
            await command.Content.CopyToAsync(memoryStream);

            var entity = new SignatureEntity
            {
                EmployeeId = command.EmployeeId,
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
