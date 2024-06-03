using System.ComponentModel.DataAnnotations.Schema;
using ChatApp.Repository.Enums.Chat;

namespace ChatApp.Repository.Entities.Chat
{
    public class ChatEntity
    {
        public string Id { get; private set; } = Guid.NewGuid().ToString();
        public string Name { get; set; } = null!;
        private ChatType _type;
        public ChatType Type
        {
            get => _type;
            set
            {
                _type = value;
                _maximumMember = _type == ChatType.Group ? MaximumMemberOfChat.GROUP :
                    _type == ChatType.Direct ? MaximumMemberOfChat.DIRECT : MaximumMemberOfChat.SELF;
            }
        }
        public int TotalMember { get; set; }

        private int _maximumMember;
        public int MaximumMember
        {
            get => _maximumMember;
            set
            {
                _maximumMember = _type == ChatType.Group ? value 
                    : throw new InvalidOperationException("Cannot change MaximumMember for Direct or Self chat types.");
            }
        }

        private DateTimeOffset _createDate = DateTimeOffset.UtcNow;
        public DateTimeOffset CreateDate
        {
            get => _createDate.ToLocalTime();
            private set => _createDate = value;
        }

        #region inverse property
        [InverseProperty(property: "Chat")]
        public virtual ICollection<MessageEntity> Messages { get; set; } = new List<MessageEntity>();
        [InverseProperty(property: "Chat")]
        public virtual ICollection<GroupChatMemberEntity> GroupChatMembers { get; set; } = new List<GroupChatMemberEntity>();
        [InverseProperty(property: "Chat")]
        public virtual ICollection<WaitingMessageChatEntity> WaitingMessageChats { get; set; } = new List<WaitingMessageChatEntity>();
        #endregion inverse property
    }

    public class MaximumMemberOfChat
    {
        public const int DIRECT = 2;
        public const int SELF = 1;
        public const int GROUP = 50;
    }
}