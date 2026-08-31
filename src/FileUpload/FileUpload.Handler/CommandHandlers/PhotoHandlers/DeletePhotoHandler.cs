using ERS.Shared;
using ERS.Shared.Abstractions.CommandHandler;
using FileUpload.DTO.Commands.PhotoCommands;
using FileUpload.Repository.Entities;
using FileUpload.Repository.Repositories.Abstractions;

namespace FileUpload.Handler.CommandHandlers.PhotoHandlers
{
    public class DeletePhotoHandler : ICommandHandler<DeletePhotoCommand>
    {
        private readonly IFileUploadRepository<PhotoEntity> _repository;

        public DeletePhotoHandler(IFileUploadRepository<PhotoEntity> repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Event>> HandleAsync(DeletePhotoCommand command)
        {
            await _repository.DeleteAsync(command.Id);
            return [];
        }
    }
}
