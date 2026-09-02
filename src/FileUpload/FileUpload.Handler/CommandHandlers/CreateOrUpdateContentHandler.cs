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
            var content = _contentRepository.GetByIdAsync(command.BdjobsId, command.FileType);
            
                
            if (content != null)
            {
                var insertContentDto = _contentAggregate.InsertCommandToEntity(command)
                    ?? throw new Exception("Failed to convert command to DTO");
                var newContent = _contentRepository.InsertAsync(insertContentDto);
                if(newContent.Result < 0) throw new Exception("Failed to insert content");
            }

            var updateContentDto = _contentAggregate.UpdateCommandToEntity(command)
                ?? throw new Exception("Failed to convert command to DTO");

            var updateContent = _contentRepository.UpdateAsync(updateContentDto);
            if (!updateContent.Result) throw new Exception("Failed to update content");

            return Task.FromResult<IEnumerable<Event>>(new[] { new Event { message = "Content saved successfully" } } );
        }
    }
}
