using ERS.Shared.Abstractions.CommandHandler;
using ERS.Shared.Abstractions.QueryHandler;
using FileUpload.DTO.Commands;
using FileUpload.DTO.Queries;
using FileUpload.DTO.Results;
using Microsoft.AspNetCore.Mvc;

namespace FileUpload.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UploadContentController : ControllerBase
    {
        private readonly IServiceProvider _serviceProvider;
        public UploadContentController(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        [HttpPost("Upload/Photo")]
        public async Task<IActionResult> UploadPhoto(string fileType, IFormFile file)
        {
            await using var memoryStream = new MemoryStream();
            await file.CopyToAsync(memoryStream);
            var command = new CreateOrUpdateContentCommand
            {
                FileName = Path.GetFileName(file.FileName.Replace('\\', '/')),
                FileType = fileType,
                ContentType = file.ContentType,
                SizeBytes = file.Length,
                FileData = memoryStream.ToArray()
            };

            var handler = _serviceProvider.GetRequiredService<ICommandHandler<CreateOrUpdateContentCommand>>();
            return Ok(await handler.HandleAsync(command));
        }

        [HttpGet("Photo")]
        public async Task<IActionResult> GetPhoto([FromQuery] GetContentQuery query)
        {
            var handler = _serviceProvider.GetRequiredService<IQueryHandler<GetContentQuery, ContentResponse>>();
            var result = await handler.HandleAsync(query);
            return Ok(result);
        }

        [HttpDelete("Photo")]
        public async Task<IActionResult> DeletePhoto([FromQuery] DeleteContentCommand command)
        {
            var handler = _serviceProvider.GetRequiredService<ICommandHandler<DeleteContentCommand>>();
            return Ok(await handler.HandleAsync(command));
        }
    }
}
