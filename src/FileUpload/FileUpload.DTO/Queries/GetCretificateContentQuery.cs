using ERS.Shared.Abstractions.Query;
using FileUpload.DTO.Results;

namespace FileUpload.DTO.Queries
{
    public sealed record GetCretificateContentQuery : IQuery<CertificateContentResponse>
    {
        public long Id { get; set; }
    }
}
