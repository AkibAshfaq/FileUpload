using ERS.Shared;
using ERS.Shared.Abstractions.CommandHandler;
using FileUpload.AggregateRoot;
using FileUpload.DTO.Commands;
using FileUpload.Repository.Repositories.Abstractions;

namespace FileUpload.Handler.CommandHandlers
{
    public class CreateOrUpdateContentHandler : ICommandHandler<CreateOrUpdateContentCommand>
    {
        private readonly IFileUploadRepository<FileUploadAggregate> _contentRepository;
        private readonly FileUploadAggregate _contentAggregate;
        public CreateOrUpdateContentHandler(IFileUploadRepository<FileUploadAggregate> fileUploadRepository, FileUploadAggregate fileUploadAggregate)
        {
            _contentRepository = fileUploadRepository;
            _contentAggregate = fileUploadAggregate;
        }
        public Task<IEnumerable<Event>> HandleAsync(CreateOrUpdateContentCommand command)
        {
            var content = _contentRepository.GetByIdAsync(command.Id);
            var contentDto = _contentAggregate.CommandToEntity(command)
                    ?? throw new Exception("Failed to convert command to DTO");
            if (content != null)
            {
                var newContent = _contentRepository.InsertAsync(contentDto);
                if(newContent.Result < 0) throw new Exception("Failed to insert content");
            }

            var updateContent = _contentRepository.UpdateAsync(contentDto);
            if (!updateContent.Result) throw new Exception("Failed to update content");

            return Task.FromResult<IEnumerable<Event>>(new[] { new Event { message = "Content saved successfully" } } );
        }
    }
}
