using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices;
using ChatApp.Repository.Enums.Chat;

namespace ChatApp.Repository.Entities.Chat
{
    public class ChatEntity
    {
        public string Id { get; private set; } = Guid.NewGuid().ToString();
        public string Name { get; set; } = null!;
        public ChatType Type { get; set; }
        public int TotalMember { get; set; }
        public int MaximumMeber { get; set; }
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
        #endregion inverse property
    }


    public class MaxiumMemberOfChat
    {
        public const int DIRECT = 2;
        public const int SELF = 1;
        public const int GROUP = 50;
    }
}