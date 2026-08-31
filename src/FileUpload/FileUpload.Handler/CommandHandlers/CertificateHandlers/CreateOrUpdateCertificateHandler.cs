using ERS.Shared;
using ERS.Shared.Abstractions.CommandHandler;
using FileUpload.DTO.Commands.CertificateCommands;

namespace FileUpload.Handler.CommandHandlers.CertificateHandlers
{
    public class CreateOrUpdateCertificateHandler : ICommandHandler<CreateOrUpdateCertificateCommand>
    {
        public Task<IEnumerable<Event>> HandleAsync(CreateOrUpdateCertificateCommand command)
        {
            throw new NotImplementedException();
        }
    }
}
