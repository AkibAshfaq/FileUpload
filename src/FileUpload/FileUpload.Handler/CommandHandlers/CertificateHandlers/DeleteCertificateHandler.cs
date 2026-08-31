using ERS.Shared;
using ERS.Shared.Abstractions.CommandHandler;
using FileUpload.DTO.Commands.CertificateCommands;

namespace FileUpload.Handler.CommandHandlers.CertificateHandlers
{
    public class DeleteCertificateHandler : ICommandHandler<DeleteCertificateCommand>
    {
        public Task<IEnumerable<Event>> HandleAsync(DeleteCertificateCommand command)
        {
            throw new NotImplementedException();
        }
    }
}
