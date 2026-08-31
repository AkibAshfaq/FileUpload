

using ERS.Shared;
using ERS.Shared.Abstractions.CommandHandler;
using FileUpload.DTO.Commands.SignatureCommands;

namespace FileUpload.Handler.CommandHandlers.SignatureHandlers
{
    public class UpdateSignatureHandler : ICommandHandler<UpdateSignatureCommand>
    {
        public Task<IEnumerable<Event>> HandleAsync(UpdateSignatureCommand command)
        {
            throw new NotImplementedException();
        }
    }
}
