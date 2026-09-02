using FileUpload.DTO.Commands;
using FileUpload.DTO.Results;
using FluentValidation;

namespace FileUpload.AggregateRoot
{
    public class FileUploadAggregate
    {
        private readonly IValidator<CreateOrUpdateContentCommand> _validator;
        public FileUploadAggregate(IValidator<CreateOrUpdateContentCommand> validator)
        {
            _validator = validator;
        }
        public FileUploadAggregate() { }

        public int Id { get; set; }
        public int BdjobsId { get; set; }
        public bool? BdjobsPhoto {  get; set; }
        public string? PhotoUrl { get; set; }
        public DateTime? PhotoPostedOn { get; set; }
        public string? ProfessionalCertification { get; set; }
        public bool? Signature { get; set; }
        public string? SignatureUrl { get; set; }
        public DateTime? SignaturePostedOn { get; set; }
        public bool? Certificate { get; set; }
        public string? CertificateUrl { get; set; }
        public DateTime? CertificatePostedOn { get; set; }

        public FileUploadAggregate CommandToEntity(CreateOrUpdateContentCommand command) 
        {
            _validator.ValidateAndThrow(command);

            return new FileUploadAggregate(_validator)
            {
                BdjobsId = command.Id,
                BdjobsPhoto = command.HasBdjobsPhoto,
                PhotoUrl = command.PhotosUrl,
                PhotoPostedOn = command.PhotoPostedOn,
                //ProfessionalCertification = command.ProfessionalCertification,
                Signature = command.HasSignature,
                SignatureUrl = command.SignaturesUrl,
                SignaturePostedOn = command.SignaturePostedOn,
                Certificate = command.HasCertificate,
                CertificateUrl = command.CertificationUrl,
                CertificatePostedOn = command.CertificatePostedOn
            };

        }

        public ContentResponse AggToResponse(FileUploadAggregate file)
        {
            return new ContentResponse
            {
                Id = file.BdjobsId,
                HasBdjobsPhoto = file.BdjobsPhoto,
                PhotosUrl = file.PhotoUrl,
                PhotoPostedOn = file.PhotoPostedOn,
                ProfessionalCertification = file.ProfessionalCertification,
                HasSignature = file.Signature,
                SignaturesUrl = file.SignatureUrl,
                SignaturePostedOn = file.SignaturePostedOn,
                HasCertificate = file.Certificate,
                CertificationUrl = file.CertificateUrl,
                CertificatePostedOn = file.CertificatePostedOn
            };
        }
    }
}
