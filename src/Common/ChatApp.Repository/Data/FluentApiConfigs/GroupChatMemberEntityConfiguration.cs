using ChatApp.Repository.Constants;
using ChatApp.Repository.Entities.Chat;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ChatApp.Repository.Data.FluentApiConfigs
{
    public class GroupChatMemberEntityConfiguration : IEntityTypeConfiguration<GroupChatMemberEntity>
    {
        public void Configure(EntityTypeBuilder<GroupChatMemberEntity> entity)
        {
            entity.ToTable(name: DatabaseConstant.GROUP_CHAT_MEMBER_TABLE_NAME);
            entity.HasKey(gcm => new { gcm.ChatId, gcm.UserId });

            entity.HasOne(gcm => gcm.Chat)
                   .WithMany(chat => chat.GroupChatMembers)
                   .HasForeignKey(gcm => gcm.ChatId);

            entity.HasOne(gcm => gcm.User)
                   .WithMany(user => user.GroupChatMembers)
                   .HasForeignKey(gcm => gcm.UserId);

            entity.Property(gcm => gcm.Role)
                   .HasConversion<int>()
                   .IsRequired();

            entity.Property(gcm => gcm.JoinDate)
                   .IsRequired();

            entity.HasIndex(gcm => gcm.ChatId);
            entity.HasIndex(gcm => gcm.UserId);
        }
    }

}