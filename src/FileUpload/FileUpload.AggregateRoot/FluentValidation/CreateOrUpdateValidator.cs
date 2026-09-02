using FileUpload.DTO.Commands;
using FluentValidation;

namespace FileUpload.AggregateRoot.FluentValidation
{
    public class CreateOrUpdateValidator : AbstractValidator<CreateOrUpdateContentCommand>
    {
        //private static readonly string[] AllowedFileTypes =
        //    { "Certificate", "Signature", "Photo" };

        //private static readonly HashSet<string> AllowedContentTypes =
        //    new(StringComparer.OrdinalIgnoreCase)
        //    { "application/pdf", "image/jpeg", "image/png" };
        private static bool BeAValidUrl(string? url)
        {
            if (string.IsNullOrWhiteSpace(url)) return false;
            return Uri.TryCreate(url, UriKind.Absolute, out _);
        }

        public CreateOrUpdateValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("BdjobsId must be greater than 0.");
            RuleFor(x => x.PhotosUrl)
                .Must(BeAValidUrl).When(x => !string.IsNullOrEmpty(x.PhotosUrl))
                .WithMessage("PhotosUrl must be a valid URL.");
            RuleFor(x => x.SignaturesUrl)
                .Must(BeAValidUrl).When(x => !string.IsNullOrEmpty(x.SignaturesUrl))
                .WithMessage("SignaturesUrl must be a valid URL.");
            RuleFor(x => x.CertificationUrl)
                .Must(BeAValidUrl).When(x => !string.IsNullOrEmpty(x.CertificationUrl))
                .WithMessage("CertificationUrl must be a valid URL.");

        }
    }
}
