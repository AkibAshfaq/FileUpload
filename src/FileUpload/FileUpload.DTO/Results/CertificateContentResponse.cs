using ERS.Shared.Abstractions.Result;
using System.Text.Json.Serialization;

namespace FileUpload.DTO.Results
{
    public sealed record CertificateContentResponse : IResult
    {
        public long Id { get; set; }
        public long EmployeeId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string? IssuedBy { get; set; }
        public DateOnly? IssuedOn { get; set; }
        public DateOnly? ExpiresOn { get; set; }
        public string FileName { get; set; } = string.Empty;
        public string ContentType { get; set; } = string.Empty;
        public long SizeBytes { get; set; }
        public DateTime UploadedAtUtc { get; set; }
        [JsonIgnore]
        public byte[] Content { get; set; } = [];
    }
}
