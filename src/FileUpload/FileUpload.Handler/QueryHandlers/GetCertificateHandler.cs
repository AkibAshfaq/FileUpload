using ERS.Shared.Abstractions.QueryHandler;
using FileUpload.DTO.Queries;
using FileUpload.DTO.Results;
using FileUpload.Repository.Entities;
using FileUpload.Repository.Repositories.Abstractions;

namespace FileUpload.Handler.QueryHandlers
{
    public class GetCertificateHandler : IQueryHandler<GetCretificateContentQuery, CertificateContentResponse>
    {
        private readonly IFileUploadRepository<CertificateEntity> _repository;

        public GetCertificateHandler(IFileUploadRepository<CertificateEntity> repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<CertificateContentResponse>> HandleAsync(GetCretificateContentQuery query)
        {
            var entity = await _repository.GetByIdAsync(query.Id);
            if (entity is null)
            {
                return [];
            }

            return
            [
                new CertificateContentResponse
                {
                    Id = entity.Id,
                    EmployeeId = entity.EmployeeId,
                    Title = entity.Title,
                    IssuedBy = entity.IssuedBy,
                    IssuedOn = entity.IssuedOn.HasValue ? DateOnly.FromDateTime(entity.IssuedOn.Value) : null,
                    ExpiresOn = entity.ExpiresOn.HasValue ? DateOnly.FromDateTime(entity.ExpiresOn.Value) : null,
                    FileName = entity.FileName,
                    ContentType = entity.ContentType,
                    SizeBytes = entity.SizeBytes,
                    UploadedAtUtc = entity.UploadedAtUtc,
                    Content = entity.Content
                }
            ];
        }
    }
}
