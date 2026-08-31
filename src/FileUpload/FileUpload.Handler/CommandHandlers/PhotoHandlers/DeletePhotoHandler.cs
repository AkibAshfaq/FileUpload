using ERS.Shared;
using ERS.Shared.Abstractions.CommandHandler;
using FileUpload.DTO.Commands.PhotoCommands;

namespace FileUpload.Handler.CommandHandlers.PhotoHandlers
{
    public class DeletePhotoHandler : ICommandHandler<DeletePhotoCommand>
    {
        public Task<IEnumerable<Event>> HandleAsync(DeletePhotoCommand command)
        {
            throw new NotImplementedException();
        }
    }
}
