using ERS.Shared.Abstractions.Result;
using System.Text.Json.Serialization;

namespace FileUpload.DTO.Results
{
    public sealed record SignatureContentResponse : IResult
    {
        public long Id { get; set; }
        public long EmployeeId { get; set; }
        public string FileName { get; set; } = string.Empty;
        public string ContentType { get; set; } = string.Empty;
        public long SizeBytes { get; set; }
        public DateTime UploadedAtUtc { get; set; }
        [JsonIgnore]
        public byte[] Content { get; set; } = [];
    }
}
