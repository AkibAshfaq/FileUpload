using ERS.Shared.Abstractions.CommandHandler;
using ERS.Shared.Abstractions.QueryHandler;
using FileUpload.DTO.Commands.CertificateCommands;
using FileUpload.DTO.Queries;
using FileUpload.DTO.Results;
using FileUpload.Handler.Events;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FileUpload.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UploadCertificateController : ControllerBase
    {
        private readonly ICommandHandler<CreateOrUpdateCertificateCommand> _createHandler;
        private readonly ICommandHandler<DeleteCertificateCommand> _deleteHandler;
        private readonly IQueryHandler<GetCretificateContentQuery, CertificateContentResponse> _getHandler;

        public UploadCertificateController(
            ICommandHandler<CreateOrUpdateCertificateCommand> createHandler,
            ICommandHandler<DeleteCertificateCommand> deleteHandler,
            IQueryHandler<GetCretificateContentQuery, CertificateContentResponse> getHandler)
        {
            _createHandler = createHandler;
            _deleteHandler = deleteHandler;
            _getHandler = getHandler;
        }

        [HttpPost("Upload/Certificate")]
        public async Task<IActionResult> UploadCertificate(
            IFormFile file,
            [FromQuery] long employeeId = 1,
            [FromQuery] string? title = null,
            [FromQuery] string? issuedBy = null,
            [FromQuery] DateOnly? issuedOn = null,
            [FromQuery] DateOnly? expiresOn = null)
        {
            if (file is null || file.Length == 0)
            {
                return BadRequest("No file uploaded.");
            }

            await using var stream = file.OpenReadStream();
            var command = new CreateOrUpdateCertificateCommand
            {
                EmployeeId = employeeId,
                Title = string.IsNullOrWhiteSpace(title) ? file.FileName : title,
                IssuedBy = issuedBy,
                IssuedOn = issuedOn,
                ExpiresOn = expiresOn,
                FileName = file.FileName,
                ContentType = file.ContentType,
                Length = file.Length,
                Content = stream
            };

            var events = await _createHandler.HandleAsync(command);
            var id = events.OfType<FileUploadedEvent>().FirstOrDefault()?.Id;

            return Ok(new { id });
        }

        [HttpGet("Certificate/{id:long}")]
        public async Task<IActionResult> GetCertificate(long id)
        {
            var results = await _getHandler.HandleAsync(new GetCretificateContentQuery { Id = id });
            var certificate = results.FirstOrDefault();
            if (certificate is null)
            {
                return NotFound();
            }

            return File(certificate.Content, certificate.ContentType, certificate.FileName);
        }

        [HttpDelete("Certificate/{id:long}")]
        public async Task<IActionResult> DeleteCertificate(long id)
        {
            await _deleteHandler.HandleAsync(new DeleteCertificateCommand { Id = id });
            return NoContent();
        }
    }
}
