using ERS.Shared.Abstractions.QueryHandler;
using FileUpload.AggregateRoot;
using FileUpload.DTO.Queries;
using FileUpload.DTO.Results;
using FileUpload.Repository.Repositories.Abstractions;


namespace FileUpload.Handler.QueryHandlers
{
    public class GetContentHandler : IQueryHandler<GetContentQuery, ContentResponse>
    {
        private readonly IFileUploadRepository<FileUploadAggregate> _contentRepository;
        private readonly FileUploadAggregate _contentAggregate;
        public GetContentHandler(IFileUploadRepository<FileUploadAggregate> fileUploadRepository, FileUploadAggregate fileUploadAggregate)
        {
            _contentRepository = fileUploadRepository;
            _contentAggregate = fileUploadAggregate;
        }
        public Task<IEnumerable<ContentResponse>> HandleAsync(GetContentQuery query)
        {
            var content = _contentRepository.GetByIdAsync(query.Identity);
            if (content == null) throw new Exception("Content Not Available");
            
            var contentResponse = _contentAggregate.AggToResponse(content.Result)
                ?? throw new Exception("Failed to convert entity to response");



            return Task.FromResult<IEnumerable<ContentResponse>>(new[] { contentResponse });
        }
    }
}
