using ERS.Shared.Abstractions.Command;
using System.Text.Json.Serialization;

namespace FileUpload.DTO.Commands
{
    public sealed record CreateOrUpdateContentCommand : ICommand
    {
        public int Id { get; set; }
        public List<FileUploadContent> FileUploadContents { get; set; } = new List<FileUploadContent>();

    }
}
