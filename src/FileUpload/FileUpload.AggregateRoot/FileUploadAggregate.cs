using FileUpload.DTO.Commands;
using FileUpload.DTO.Results;
using FluentValidation;

namespace FileUpload.AggregateRoot
{
    public class FileUploadAggregate
    {
        private readonly IValidator<CreateOrUpdateContentDto> _validator;
        public FileUploadAggregate(IValidator<CreateOrUpdateContentDto> validator)
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

        public CreateOrUpdateContentDto CommandToDto(CreateOrUpdateContentCommand command)
        {
            var dto = new CreateOrUpdateContentDto() { Id = command.Id };

            foreach (var fileContent in command.FileUploadContents)
            {
                if (fileContent.Type == "Signature")
                {
                    dto.HasSignature = true;
                    dto.SignaturesUrl = fileContent.FileUrl;
                    dto.SignaturePostedOn = DateTime.UtcNow;
                }
                
                if (fileContent.Type == "Certificate")
                {
                    dto.HasCertificate = true;
                    dto.CertificationUrl = fileContent.FileUrl;
                    dto.CertificatePostedOn = DateTime.UtcNow;
                }
                
                if (fileContent.Type == "Photo")
                {
                    dto.HasBdjobsPhoto = true;
                    dto.PhotosUrl = fileContent.FileUrl;
                    dto.PhotoPostedOn = DateTime.UtcNow;
                }
            }
            return dto;
        }


        public FileUploadAggregate DtoToAgg(CreateOrUpdateContentDto dto)
        {
            _validator.ValidateAndThrow(dto);
            return new FileUploadAggregate(_validator)
            {
                BdjobsId = dto.Id,
                BdjobsPhoto = dto.HasBdjobsPhoto,
                PhotoUrl = dto.PhotosUrl,
                PhotoPostedOn = dto.PhotoPostedOn,
                ProfessionalCertification = dto.ProfessionalCertification,
                Signature = dto.HasSignature,
                SignatureUrl = dto.SignaturesUrl,
                SignaturePostedOn = dto.SignaturePostedOn,
                Certificate = dto.HasCertificate,
                CertificateUrl = dto.CertificationUrl,
                CertificatePostedOn = dto.CertificatePostedOn

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
