using ERS.Shared;
using ERS.Shared.Abstractions.CommandHandler;
using FileUpload.DTO.Commands.SignatureCommands;
using FileUpload.Repository.Entities;
using FileUpload.Repository.Repositories.Abstractions;

namespace FileUpload.Handler.CommandHandlers.SignatureHandlers
{
    public class DeleteSignatureHandler : ICommandHandler<DeleteSignatureCommand>
    {
        private readonly IFileUploadRepository<SignatureEntity> _repository;

        public DeleteSignatureHandler(IFileUploadRepository<SignatureEntity> repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Event>> HandleAsync(DeleteSignatureCommand command)
        {
            await _repository.DeleteAsync(command.Id);
            return [];
        }
    }
}
