using FileUpload.API.Middlewares;
using FileUpload.DTO.Dependency;
using FileUpload.Handler.Dependency;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddHandlerDependency(builder.Configuration);
builder.Services.AddDTODependency();
builder.Services.AddTransient<FileUploadExceptionHandler>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<FileUploadExceptionHandler>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
