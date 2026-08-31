using ERS.Shared;
using ERS.Shared.Abstractions.CommandHandler;
using FileUpload.DTO.Commands.PhotoCommands;

namespace FileUpload.Handler.CommandHandlers.PhotoHandlers
{
    public class CreatePhotoHandler : ICommandHandler<CreateOrUpdatePhotoCommand>
    {
        public Task<IEnumerable<Event>> HandleAsync(CreateOrUpdatePhotoCommand command)
        {
            throw new NotImplementedException();
        }
    }
}
