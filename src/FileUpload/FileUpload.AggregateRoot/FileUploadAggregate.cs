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

        public long Id { get; set; }
        public Guid FileToken { get; set; }
        public string? DownloadUrl { get; set; }
        public long BdjobsId { get; set; }
        public string FileName { get; set; }
        public string FileType { get; set; }
        public string ContentType { get; set; }
        public long SizeBytes { get; set; }
        public byte[] FileData { get; set; }
        public DateTime CreatedAtUtc { get; set; }
        public DateTime? UpdatedAtUtc { get; set; }

        public FileUploadAggregate InsertCommandToEntity(CreateOrUpdateContentCommand command) 
        {
            _validator.ValidateAndThrow(command);

        
            return new FileUploadAggregate(_validator)
            {
                BdjobsId = command.BdjobsId,
                FileToken = command.FileToken,
                FileName = command.FileName,
                FileType = command.FileType,
                ContentType = command.ContentType,
                SizeBytes = command.SizeBytes,
                DownloadUrl = command.FileUrl,
                FileData = command.FileData,
                CreatedAtUtc = DateTime.Now,
                UpdatedAtUtc = DateTime.Now
            };

        }

        public FileUploadAggregate UpdateCommandToEntity(CreateOrUpdateContentCommand command)
        {
            _validator.ValidateAndThrow(command);


            return new FileUploadAggregate(_validator)
            {
                BdjobsId = command.BdjobsId,
                FileToken = command.FileToken,
                FileName = command.FileName,
                FileType = command.FileType,
                ContentType = command.ContentType,
                SizeBytes = command.SizeBytes,
                DownloadUrl = command.FileUrl,
                FileData = command.FileData,
                UpdatedAtUtc = DateTime.Now
            };

        }
        public ContentResponse AggToResponse(FileUploadAggregate file)
        {
            return new ContentResponse
            {
                Id = file.Id,
                BdjobsId = file.BdjobsId,
                FileToken = file.FileToken,
                FileName = file.FileName,
                FileType = file.FileType,
                ContentType = file.ContentType,
                SizeBytes = file.SizeBytes,
                FileData = file.FileData,
                DownloadUrl = file.DownloadUrl
            };
        }
    }
}
