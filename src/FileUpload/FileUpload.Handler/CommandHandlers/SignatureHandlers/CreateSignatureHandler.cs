using ERS.Shared;
using ERS.Shared.Abstractions.CommandHandler;
using FileUpload.DTO.Commands.SignatureCommands;

namespace FileUpload.Handler.CommandHandlers.SignatureHandlers
{
    public class CreateSignatureHandler : ICommandHandler<CreateOrUpdateSignatureCommand>
    {
        public Task<IEnumerable<Event>> HandleAsync(CreateOrUpdateSignatureCommand command)
        {
            throw new NotImplementedException();
        }
    }
}
