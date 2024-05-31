using ChatApp.Repository.Enums.File;

namespace ChatApp.Repository.Entities.Chat
{
    public class MessageFileEntity
    {
        public string Id { get; private set; } = Guid.NewGuid().ToString();
        public string Url { get; set; } = null!;
        public string FileName { get; set; } = null!;
        public string BlobName { get; set; } = null!;
        public FileType Type { get; set; }
        public string MessageId { get; set; } = null!;

        #region navigate property
        public MessageEntity Message { get; set; } = null!;
        #endregion navigate property
    }
}