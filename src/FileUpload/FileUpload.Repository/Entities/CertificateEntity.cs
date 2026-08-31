namespace FileUpload.Repository.Entities
{
    public sealed class CertificateEntity
    {
        public long Id { get; set; }
        public long EmployeeId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string? IssuedBy { get; set; }
        public DateTime? IssuedOn { get; set; }
        public DateTime? ExpiresOn { get; set; }
        public string FileName { get; set; } = string.Empty;
        public string ContentType { get; set; } = string.Empty;
        public long SizeBytes { get; set; }
        public byte[] Content { get; set; } = [];
        public DateTime UploadedAtUtc { get; set; }
    }
}
