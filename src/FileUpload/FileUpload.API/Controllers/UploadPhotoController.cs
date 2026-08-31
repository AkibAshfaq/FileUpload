using ERS.Shared.Abstractions.CommandHandler;
using FileUpload.DTO.Commands.CertificateCommands;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FileUpload.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UploadPhotoController : ControllerBase
    {
        private readonly IServiceProvider _serviceProvider;
        public UploadPhotoController(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        [HttpPost("Upload/Photo")]
        public async Task<IActionResult> UploadPhoto(IFormFile file)
        {
            await using var memoryStream = file.OpenReadStream();
            var command = new CreateOrUpdateCertificateCommand
            {
                EmployeeId = 1,
                Title = file.FileName,
                IssuedBy = "1",
                FileName = file.FileName,
                ContentType = file.ContentType,
                Length = file.Length,
                Content = memoryStream
            };

            var handler  = _serviceProvider.GetRequiredService<ICommandHandler<CreateOrUpdateCertificateCommand>>();
            return Ok(await handler.HandleAsync(command));
        }

        [HttpGet("Photo")]
        public IActionResult GetPhoto()
        {
            // Implementation for retrieving photo
            return Ok();
        }

        [HttpDelete("Photo")]
        public IActionResult DeletePhoto()
        {
            // Implementation for deleting photo
            return Ok();
        }

        [HttpPut("Photo")]
        public IActionResult UpdatePhoto()
        {
            // Implementation for updating photo
            return Ok();
        }
    }
}
