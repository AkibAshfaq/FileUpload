using ERS.Shared.Abstractions.QueryHandler;
using FileUpload.DTO.Queries;
using FileUpload.DTO.Results;

namespace FileUpload.Handler.QueryHandlers
{
    public class GetSignatureHandler : IQueryHandler<GetSignatureContentQuery, SignatureContentResponse>
    {
        public Task<IEnumerable<SignatureContentResponse>> HandleAsync(GetSignatureContentQuery query)
        {
            throw new NotImplementedException();
        }
    }
}
