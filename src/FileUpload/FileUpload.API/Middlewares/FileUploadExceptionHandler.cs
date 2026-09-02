namespace FileUpload.API.Middlewares
{
    public class FileUploadExceptionHandler : IMiddleware
    {
        private readonly ILogger<FileUploadExceptionHandler> _logger;
        public FileUploadExceptionHandler(ILogger<FileUploadExceptionHandler> logger)
        {
            _logger = logger;
        }
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An unhandled exception occurred during file upload.");
                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                context.Response.ContentType = "application/json";
                var errorResponse = new { message = "An error occurred while processing the file upload." };
                await context.Response.WriteAsJsonAsync(errorResponse);
            }
        }
    }
}
