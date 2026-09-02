using ERS.Shared.Abstractions.Result;
using System.Text.Json.Serialization;

namespace FileUpload.DTO.Results
{
    public sealed record ContentResponse : IResult
    {
        public long Id { get; set; }
        public long BdjobsId { get; set; }
        public Guid FileToken { get; set; }
        public string FileType { get; set; }
        public string FileName { get; set; }
        public string ContentType { get; set; }
        public long SizeBytes { get; set; }
        public DateTime UpdatedAtUtc { get; set; }
        public string? DownloadUrl { get; set; }
        [JsonIgnore]
        public byte[] FileData { get; set; } = [];
    }
}
