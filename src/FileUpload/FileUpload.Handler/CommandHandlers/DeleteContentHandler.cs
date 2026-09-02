using ERS.Shared;
using ERS.Shared.Abstractions.CommandHandler;
using FileUpload.AggregateRoot;
using FileUpload.DTO.Commands;
using FileUpload.Repository.Repositories.Abstractions;

namespace FileUpload.Handler.CommandHandlers
{

    public class DeleteContentHandler : ICommandHandler<DeleteContentCommand>
    {
        private readonly IFileUploadRepository<FileUploadAggregate> _contentRepository;
        private readonly FileUploadAggregate _contentAggregate;
        public DeleteContentHandler(IFileUploadRepository<FileUploadAggregate> fileUploadRepository, FileUploadAggregate fileUploadAggregate)
        {
            _contentRepository = fileUploadRepository;
            _contentAggregate = fileUploadAggregate;
        }

        public Task<IEnumerable<Event>> HandleAsync(DeleteContentCommand command)
        {
            var content = _contentRepository.GetByIdAsync(command.BdjobsId, command.FileType);
            if (content == null) throw new Exception("Content Not Available");

            var result = _contentRepository.DeleteAsync(command.BdjobsId, command.FileType);
            if(!result.Result) throw new Exception("Failed to delete content");
            return Task.FromResult<IEnumerable<Event>>(new[] { new Event { message = "Content deleted successfully" } });
        }
    }
}
