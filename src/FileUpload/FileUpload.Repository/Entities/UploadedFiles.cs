
namespace FileUpload.Repository.Entities
{
    public sealed record UploadedFiles
    {
        public long Id { get; set; }
        public string FileName { get; set; }
        public string ContentType { get; set; }
        public byte[] SizeBytes { get; set; }
        public string Uploadedby { get; set; }
        public Stream FileData { get; set; }

    }
}
