using ERS.Shared;
using ERS.Shared.Abstractions.CommandHandler;
using FileUpload.DTO.Commands.PhotoCommands;
using FileUpload.Handler.Events;
using FileUpload.Repository.Entities;
using FileUpload.Repository.Repositories.Abstractions;

namespace FileUpload.Handler.CommandHandlers.PhotoHandlers
{
    public class CreatePhotoHandler : ICommandHandler<CreateOrUpdatePhotoCommand>
    {
        private readonly IFileUploadRepository<PhotoEntity> _repository;

        public CreatePhotoHandler(IFileUploadRepository<PhotoEntity> repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Event>> HandleAsync(CreateOrUpdatePhotoCommand command)
        {
            using var memoryStream = new MemoryStream();
            await command.Content.CopyToAsync(memoryStream);

            var entity = new PhotoEntity
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
