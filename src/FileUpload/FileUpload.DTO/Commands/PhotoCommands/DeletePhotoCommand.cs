using ERS.Shared.Abstractions.Command;

namespace FileUpload.DTO.Commands.PhotoCommands
{
    public sealed record DeletePhotoCommand : ICommand
    {
        public long Id { get; set; }
    }
}
