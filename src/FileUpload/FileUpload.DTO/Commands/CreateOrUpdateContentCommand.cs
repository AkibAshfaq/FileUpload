using ERS.Shared.Abstractions.Command;
using System.Text.Json.Serialization;

namespace FileUpload.DTO.Commands
{
    public sealed record CreateOrUpdateContentCommand : ICommand
    {
        public long BdjobsId { get; set; }
        public string FileName { get; set; }
        public string FileType { get; set; }
        public string ContentType { get; set; }
        public long SizeBytes { get; set; }
        public byte[] FileData { get; set; }
        public Guid FileToken { get; set; }
        public string? FileUrl { get; set; }

    }
}
