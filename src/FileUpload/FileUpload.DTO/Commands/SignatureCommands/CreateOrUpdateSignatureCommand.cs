using ERS.Shared.Abstractions.Command;

namespace FileUpload.DTO.Commands.SignatureCommands
{
    public sealed record CreateOrUpdateSignatureCommand : ICommand
    {
        public required long EmployeeId { get; set; }
        public required string FileName { get; set; }
        public required string ContentType { get; set; }
        public required long Length { get; set; }
        public required Stream Content { get; set; }
    }
}
