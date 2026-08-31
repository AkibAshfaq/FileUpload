namespace FileUpload.Repository.Entities
{
    public sealed class SignatureEntity
    {
        public long Id { get; set; }
        public long EmployeeId { get; set; }
        public string FileName { get; set; } = string.Empty;
        public string ContentType { get; set; } = string.Empty;
        public long SizeBytes { get; set; }
        public byte[] Content { get; set; } = [];
        public DateTime UploadedAtUtc { get; set; }
    }
}
