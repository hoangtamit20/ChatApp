using System.ComponentModel.DataAnnotations.Schema;
using ChatApp.Repository.Entities.User;

namespace ChatApp.Repository.Entities.Chat
{
    [Table(name: "Message")]
    public class MessageEntity
    {
        public string Id { get; private set; } = Guid.NewGuid().ToString();
        public string Content { get; set; } = string.Empty;
        public bool IsIncludeFile { get; set; } = false;
        public DateTimeOffset _sendDate { get; private set; } = DateTimeOffset.UtcNow;
        public DateTimeOffset SendDate
        {
            get => _sendDate.ToLocalTime();
            private set => _sendDate = value;
        }
        public string SenderId { get; set; } = null!;
        public string ChatId { get; set; } = null!;

        #region navigate property
        [ForeignKey(name: "SenderId")]
        [InverseProperty(property: "Messages")]
        public virtual UserEntity Sender { get; set; } = null!;
        [ForeignKey(name: "ChatId")]
        [InverseProperty(property: "Messages")]
        public virtual ChatEntity Chat { get; set; } = null!;
        #endregion navigate property

        #region inverse property
        [InverseProperty(property: "Message")]
        public virtual ICollection<MessageFileEntity> MessageFiles { get; set; } = new List<MessageFileEntity>();
        #endregion inverse property
    }
}