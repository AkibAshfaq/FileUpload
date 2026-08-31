using ERS.Shared.Abstractions.QueryHandler;
using FileUpload.DTO.Results;

namespace FileUpload.Handler.QueryHandlers
{
    public class GetCertificateHandler : IQueryHandler<GetCertificateHandler, CertificateContentResponse>
    {
        public Task<IEnumerable<CertificateContentResponse>> HandleAsync(GetCertificateHandler query)
        {
            throw new NotImplementedException();
        }
    }
}
