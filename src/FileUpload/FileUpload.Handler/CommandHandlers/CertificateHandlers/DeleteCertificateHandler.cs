using ERS.Shared;
using ERS.Shared.Abstractions.CommandHandler;
using FileUpload.DTO.Commands.CertificateCommands;
using FileUpload.Repository.Entities;
using FileUpload.Repository.Repositories.Abstractions;

namespace FileUpload.Handler.CommandHandlers.CertificateHandlers
{
    public class DeleteCertificateHandler : ICommandHandler<DeleteCertificateCommand>
    {
        private readonly IFileUploadRepository<CertificateEntity> _repository;

        public DeleteCertificateHandler(IFileUploadRepository<CertificateEntity> repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Event>> HandleAsync(DeleteCertificateCommand command)
        {
            await _repository.DeleteAsync(command.Id);
            return [];
        }
    }
}
