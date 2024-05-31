
using System.ComponentModel.DataAnnotations.Schema;
using ChatApp.Repository.Entities.Chat;
using ChatApp.Repository.Enums.User;
using Microsoft.AspNetCore.Identity;

namespace ChatApp.Repository.Entities.User
{
    public class UserEntity : IdentityUser
    {
        #region 'User property'
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public SexType Sex { get; set; }
        public DateOnly? DateOfBirth { get; set; }
        public string? Address { get; set; }
        public string? Picture { get; set; }
        private DateTimeOffset _createdDate = DateTimeOffset.UtcNow;
        public DateTimeOffset CreatedDate { get => _createdDate.ToLocalTime();
            private set => _createdDate = value; }
        public string FullName
        {
            get
            {
                return $"{FirstName} {LastName}";
            }
        }
        #endregion 'User property'



        #region inverse property
        [InverseProperty(property: "Sender")]
        public virtual ICollection<MessageEntity> Messages { get; set; } = new List<MessageEntity>();
        [InverseProperty(property: "User")]
        public virtual ICollection<GroupChatMemberEntity> GroupChatMembers { get; set; } = new List<GroupChatMemberEntity>();
        #endregion inverse property



    }
}