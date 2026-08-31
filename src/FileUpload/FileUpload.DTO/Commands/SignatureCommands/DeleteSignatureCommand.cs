using ERS.Shared.Abstractions.Command;

namespace FileUpload.DTO.Commands.SignatureCommands
{
    public sealed record DeleteSignatureCommand : ICommand
    {
        public long Id { get; set; }
    }
}
