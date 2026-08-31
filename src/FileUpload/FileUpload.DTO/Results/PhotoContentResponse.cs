using ERS.Shared.Abstractions.Result;

namespace FileUpload.DTO.Results
{
    public sealed record PhotoContentResponse : IResult
    {
        public long Id { get; set; }
        public string FileName { get; set; } = string.Empty;
        public string ContentType { get; set; } = string.Empty;
        public long SizeBytes { get; set; }
        public byte[] Content { get; set; } = [];
    }
}
