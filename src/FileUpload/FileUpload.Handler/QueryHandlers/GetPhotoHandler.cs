using ERS.Shared.Abstractions.QueryHandler;
using FileUpload.DTO.Queries;
using FileUpload.DTO.Results;
using FileUpload.Repository.Entities;
using FileUpload.Repository.Repositories.Abstractions;

namespace FileUpload.Handler.QueryHandlers
{
    public class GetPhotoHandler : IQueryHandler<GetPhotoContentQuery, PhotoContentResponse>
    {
        private readonly IFileUploadRepository<PhotoEntity> _repository;

        public GetPhotoHandler(IFileUploadRepository<PhotoEntity> repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<PhotoContentResponse>> HandleAsync(GetPhotoContentQuery query)
        {
            var entity = await _repository.GetByIdAsync(query.Id);
            if (entity is null)
            {
                return [];
            }

            return
            [
                new PhotoContentResponse
                {
                    Id = entity.Id,
                    FileName = entity.FileName,
                    ContentType = entity.ContentType,
                    SizeBytes = entity.SizeBytes,
                    Content = entity.Content
                }
            ];
        }
    }
}
