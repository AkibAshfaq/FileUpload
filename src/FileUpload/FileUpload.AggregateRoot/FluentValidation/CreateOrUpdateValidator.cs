using FileUpload.DTO.Commands;
using FluentValidation;

namespace FileUpload.AggregateRoot.FluentValidation
{
    public class CreateOrUpdateValidator : AbstractValidator<CreateOrUpdateContentCommand>
    {
        private static readonly string[] AllowedFileTypes =
            { "Certificate", "Signature", "Photo" };

        private static readonly HashSet<string> AllowedContentTypes =
            new(StringComparer.OrdinalIgnoreCase)
            { "application/pdf", "image/jpeg", "image/png" };

        public CreateOrUpdateValidator()
        {
            RuleFor(x => x.FileName)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("File name is required.")
                .Must(n => n == Path.GetFileName(n))
                    .WithMessage("File name must not contain a path.")
                .Must(n => n.IndexOfAny(Path.GetInvalidFileNameChars()) < 0)
                    .WithMessage("File name contains invalid characters.");

            RuleFor(x => x.FileType)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("File type is required.")
                .Must(ft => AllowedFileTypes.Contains(ft))
                    .WithMessage(x => $"File type '{x.FileType}' is not supported. Allowed: {string.Join(", ", AllowedFileTypes)}.");

            RuleFor(x => x.ContentType)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("File content type is required.")
                .Must(BeAllowedContentType)
                    .WithMessage(x => $"Content type '{x.ContentType}' is not supported. Allowed: {string.Join(", ", AllowedContentTypes)}.");

            RuleFor(x => x.SizeBytes)
                .GreaterThan(0).WithMessage("File is empty.")
                .LessThanOrEqualTo(1_048_576)
                    .WithMessage("File size must not exceed 1 MB.");
        }

        private static bool BeAllowedContentType(string? contentType)
        {
            if (string.IsNullOrWhiteSpace(contentType)) return false;
            var mediaType = contentType.Split(';')[0].Trim();   // drop "; charset=..."
            return AllowedContentTypes.Contains(mediaType);
        }
    }
}
