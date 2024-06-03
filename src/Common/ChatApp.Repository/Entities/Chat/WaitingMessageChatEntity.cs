using System.ComponentModel.DataAnnotations.Schema;
using ChatApp.Repository.Entities.User;

namespace ChatApp.Repository.Entities.Chat
{
    public class WaitingMessageChatEntity
    {
        public string UserId { get; set; } = null!;
        public string ChatId { get; set; } = null!;
        public int UnReadMessageCount { get; set; }
        public int NewMessageCount { get; set; }
        private DateTimeOffset? _lastRecievedMessage;
        public DateTimeOffset? LastRecievedMessage
        {
            get => _lastRecievedMessage?.ToLocalTime();
            set => _lastRecievedMessage = value?.ToUniversalTime();
        }

        #region navigate property
        [ForeignKey(name: "UserId")]
        [InverseProperty(property: "WaitingMessageChats")]
        public virtual UserEntity User { get; set; } = null!;
        [ForeignKey(name: "ChatId")]
        [InverseProperty(property: "WaitingMessageChats")]
        public virtual ChatEntity Chat { get; set; } = null!;

        #endregion navigate property
    }
}