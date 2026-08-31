using ERS.Shared;
using ERS.Shared.Abstractions.CommandHandler;
using FileUpload.DTO.Commands.SignatureCommands;

namespace FileUpload.Handler.CommandHandlers.SignatureHandlers
{
    public class DeleteSignatureHandler : ICommandHandler<DeleteSignatureCommand>
    {
        public Task<IEnumerable<Event>> HandleAsync(DeleteSignatureCommand command)
        {
            throw new NotImplementedException();
        }
    }
}
