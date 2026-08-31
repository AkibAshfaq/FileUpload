using ERS.Shared.Abstractions.Command;

namespace FileUpload.DTO.Commands.CertificateCommands
{
    public sealed record CreateOrUpdateCertificateCommand : ICommand
    {
        public required long EmployeeId { get; set; }
        public required string Title { get; set; }
        public string? IssuedBy { get; set; }
        public DateOnly? IssuedOn { get; set; }
        public DateOnly? ExpiresOn { get; set; }

        public required string FileName { get; set; }
        public required string ContentType { get; set; }
        public required long Length { get; set; }
        public required Stream Content { get; set; }
    }
}
