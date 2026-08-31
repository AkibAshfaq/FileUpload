using ERS.Shared.Abstractions.QueryHandler;
using FileUpload.DTO.Queries;
using FileUpload.DTO.Results;

namespace FileUpload.Handler.QueryHandlers
{
    public class GetPhotoHandler : IQueryHandler<GetPhotoContentQuery, PhotoContentResponse>
    {
        public Task<IEnumerable<PhotoContentResponse>> HandleAsync(GetPhotoContentQuery query)
        {
            throw new NotImplementedException();
        }
    }
}
