using FileUpload.DTO.Dependency;
using FileUpload.Handler.Dependency;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddHandlerDependency(builder.Configuration);
builder.Services.AddDTODependency();

var app = builder.Build();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
