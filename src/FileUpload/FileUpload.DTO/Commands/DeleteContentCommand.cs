using ERS.Shared.Abstractions.Command;

namespace FileUpload.DTO.Commands
{
    public sealed record DeleteContentCommand : ICommand
    {
        public long BdjobsId { get; set; }
        public string FileType { get; set; }
    }
}
