using ERS.Shared.Abstractions.Query;
using FileUpload.DTO.Results;

namespace FileUpload.DTO.Queries
{
    public class GetContentQuery : IQuery<ContentResponse>
    {
        public long Identity { get; set; }
        public string FileType { get; set; }

    }
}
