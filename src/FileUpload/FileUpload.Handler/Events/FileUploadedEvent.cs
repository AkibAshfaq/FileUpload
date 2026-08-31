using ERS.Shared;

namespace FileUpload.Handler.Events
{
    public sealed class FileUploadedEvent : Event
    {
        public required long Id { get; init; }
    }
}
