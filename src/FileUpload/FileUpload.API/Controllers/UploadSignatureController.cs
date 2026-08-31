using ERS.Shared.Abstractions.CommandHandler;
using ERS.Shared.Abstractions.QueryHandler;
using FileUpload.DTO.Commands.SignatureCommands;
using FileUpload.DTO.Queries;
using FileUpload.DTO.Results;
using FileUpload.Handler.Events;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FileUpload.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UploadSignatureController : ControllerBase
    {
        private readonly ICommandHandler<CreateOrUpdateSignatureCommand> _createHandler;
        private readonly ICommandHandler<DeleteSignatureCommand> _deleteHandler;
        private readonly IQueryHandler<GetSignatureContentQuery, SignatureContentResponse> _getHandler;

        public UploadSignatureController(
            ICommandHandler<CreateOrUpdateSignatureCommand> createHandler,
            ICommandHandler<DeleteSignatureCommand> deleteHandler,
            IQueryHandler<GetSignatureContentQuery, SignatureContentResponse> getHandler)
        {
            _createHandler = createHandler;
            _deleteHandler = deleteHandler;
            _getHandler = getHandler;
        }

        [HttpPost("Upload/Signature")]
        public async Task<IActionResult> UploadSignature(IFormFile file, [FromQuery] long employeeId = 1)
        {
            if (file is null || file.Length == 0)
            {
                return BadRequest("No file uploaded.");
            }

            await using var stream = file.OpenReadStream();
            var command = new CreateOrUpdateSignatureCommand
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

        [HttpGet("Signature/{id:long}")]
        public async Task<IActionResult> GetSignature(long id)
        {
            var results = await _getHandler.HandleAsync(new GetSignatureContentQuery { Id = id });
            var signature = results.FirstOrDefault();
            if (signature is null)
            {
                return NotFound();
            }

            return File(signature.Content, signature.ContentType, signature.FileName);
        }

        [HttpDelete("Signature/{id:long}")]
        public async Task<IActionResult> DeleteSignature(long id)
        {
            await _deleteHandler.HandleAsync(new DeleteSignatureCommand { Id = id });
            return NoContent();
        }
    }
}
