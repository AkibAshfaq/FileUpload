using ERS.Shared.Abstractions.Command;

namespace FileUpload.DTO.Commands.CertificateCommands
{
    public sealed record DeleteCertificateCommand: ICommand
    {
        public long Id { get; set; }
    }
}
