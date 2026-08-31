using ERS.Shared.Abstractions.Query;
using FileUpload.DTO.Results;

namespace FileUpload.DTO.Queries
{
    public sealed record GetSignatureContentQuery : IQuery<SignatureContentResponse>
    {
        public long Id { get; set; }
    }
}
