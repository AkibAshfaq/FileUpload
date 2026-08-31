using ERS.Shared.Abstractions.CommandHandler;
using ERS.Shared.Abstractions.QueryHandler;
using FileUpload.DTO.Commands.PhotoCommands;
using FileUpload.DTO.Queries;
using FileUpload.DTO.Results;
using FileUpload.Handler.Events;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FileUpload.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UploadPhotoController : ControllerBase
    {
        private readonly ICommandHandler<CreateOrUpdatePhotoCommand> _createHandler;
        private readonly ICommandHandler<DeletePhotoCommand> _deleteHandler;
        private readonly IQueryHandler<GetPhotoContentQuery, PhotoContentResponse> _getHandler;

        public UploadPhotoController(
            ICommandHandler<CreateOrUpdatePhotoCommand> createHandler,
            ICommandHandler<DeletePhotoCommand> deleteHandler,
            IQueryHandler<GetPhotoContentQuery, PhotoContentResponse> getHandler)
        {
            _createHandler = createHandler;
            _deleteHandler = deleteHandler;
            _getHandler = getHandler;
        }

        [HttpPost("Upload/Photo")]
        public async Task<IActionResult> UploadPhoto(IFormFile file, [FromQuery] long employeeId = 1)
        {
            if (file is null || file.Length == 0)
            {
                return BadRequest("No file uploaded.");
            }

            await using var stream = file.OpenReadStream();
            var command = new CreateOrUpdatePhotoCommand
            {
                EmployeeId = employeeId,
                FileName = file.FileName,
                ContentType = file.ContentType,
                Length = file.Length,
                Content = stream
            };

            var events = await _createHandler.HandleAsync(command);
            var id = events.OfType<FileUploadedEvent>().FirstOrDefault()?.Id;

            return Ok(new { id });
        }

        [HttpGet("Photo/{id:long}")]
        public async Task<IActionResult> GetPhoto(long id)
        {
            var results = await _getHandler.HandleAsync(new GetPhotoContentQuery { Id = id });
            var photo = results.FirstOrDefault();
            if (photo is null)
            {
                return NotFound();
            }

            return File(photo.Content, photo.ContentType, photo.FileName);
        }

        [HttpDelete("Photo/{id:long}")]
        public async Task<IActionResult> DeletePhoto(long id)
        {
            await _deleteHandler.HandleAsync(new DeletePhotoCommand { Id = id });
            return NoContent();
        }
    }
}
