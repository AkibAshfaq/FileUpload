using ERS.Shared.Abstractions.Command;

namespace FileUpload.DTO.Commands
{
    public sealed record CreateOrUpdateContentDto : ICommand
    {
        public int Id { get; set; }
        public bool? HasBdjobsPhoto { get; set; }
        public string? PhotosUrl { get; set; }
        public DateTime? PhotoPostedOn { get; set; }
        public string? ProfessionalCertification { get; set; }
        public bool? HasSignature { get; set; }
        public string? SignaturesUrl { get; set; }
        public DateTime? SignaturePostedOn { get; set; }
        public bool HasCertificate { get; set; }
        public string? CertificationUrl { get; set; }
        public DateTime? CertificatePostedOn { get; set; }
    }
}
