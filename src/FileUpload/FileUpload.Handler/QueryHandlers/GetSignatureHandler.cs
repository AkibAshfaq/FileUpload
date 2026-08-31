using ERS.Shared.Abstractions.QueryHandler;
using FileUpload.DTO.Queries;
using FileUpload.DTO.Results;
using FileUpload.Repository.Entities;
using FileUpload.Repository.Repositories.Abstractions;

namespace FileUpload.Handler.QueryHandlers
{
    public class GetSignatureHandler : IQueryHandler<GetSignatureContentQuery, SignatureContentResponse>
    {
        private readonly IFileUploadRepository<SignatureEntity> _repository;

        public GetSignatureHandler(IFileUploadRepository<SignatureEntity> repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<SignatureContentResponse>> HandleAsync(GetSignatureContentQuery query)
        {
            var entity = await _repository.GetByIdAsync(query.Id);
            if (entity is null)
            {
                return [];
            }

            return
            [
                new SignatureContentResponse
                {
                    Id = entity.Id,
                    EmployeeId = entity.EmployeeId,
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
