using System.ComponentModel.DataAnnotations.Schema;
using ChatApp.Repository.Entities.User;
using ChatApp.Repository.Enums.Chat;

namespace ChatApp.Repository.Entities.Chat
{
    public class GroupChatMemberEntity
    {
        public string ChatId { get; set; } = null!;
        public string UserId { get; set; } = null!;
        public ChatRole Role { get; set; }
        private DateTimeOffset _joinDate = DateTimeOffset.UtcNow;
        public DateTimeOffset JoinDate
        {
            get => _joinDate.ToLocalTime();
            private set => _joinDate = value;
        }
        private DateTimeOffset? _leaveDate;
        public DateTimeOffset? LeaveDate
        {
            get => _leaveDate?.ToLocalTime();
            set => value?.ToUniversalTime();
        }

        #region navigate property
        [ForeignKey(name: "ChatId")]
        [InverseProperty(property: "GroupChatMembers")]
        public virtual ChatEntity Chat { get; set; } = null!;
        [ForeignKey(name: "UserId")]
        [InverseProperty(property: "GroupChatMembers")]
        public virtual UserEntity User { get; set; } = null!;
        #endregion navigate property
    }
}