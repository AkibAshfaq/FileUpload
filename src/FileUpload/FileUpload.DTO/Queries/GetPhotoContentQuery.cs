using ERS.Shared.Abstractions.Query;
using FileUpload.DTO.Results;

namespace FileUpload.DTO.Queries
{
    public sealed record GetPhotoContentQuery : IQuery<PhotoContentResponse>
    {
        public long Id { get; set; }
    }
}
