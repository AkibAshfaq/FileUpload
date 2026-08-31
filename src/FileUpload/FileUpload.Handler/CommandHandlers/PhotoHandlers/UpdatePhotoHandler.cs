using ERS.Shared;
using ERS.Shared.Abstractions.CommandHandler;

namespace FileUpload.Handler.CommandHandlers.PhotoHandlers
{
    public class UpdatePhotoHandler : ICommandHandler<UpdatePhotoHandler>
    {
        public Task<IEnumerable<Event>> HandleAsync(UpdatePhotoHandler command)
        {
            throw new NotImplementedException();
        }
    }
}
