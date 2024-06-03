using ChatApp.Repository.Constants;
using ChatApp.Repository.Entities.Chat;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ChatApp.Repository.Data.FluentApiConfigs
{
    public class WaitingMessageChatEntityConfiguration : IEntityTypeConfiguration<WaitingMessageChatEntity>
    {
        public void Configure(EntityTypeBuilder<WaitingMessageChatEntity> builder)
        {
            builder.ToTable(name: DatabaseConstant.WAITING_MESSAGE_CHAT_TABLE_NAME);
            builder.HasKey(wm => new { wm.UserId, wm.ChatId });

            builder.Property(wm => wm.UnReadMessageCount)
                   .IsRequired();

            builder.Property(wm => wm.NewMessageCount)
                   .IsRequired();

            builder.Property(wm => wm.LastRecievedMessage)
                   .IsRequired(false);

            builder.HasOne(wm => wm.User)
                   .WithMany(user => user.WaitingMessageChats)
                   .HasForeignKey(wm => wm.UserId);

            builder.HasOne(wm => wm.Chat)
                   .WithMany(chat => chat.WaitingMessageChats)
                   .HasForeignKey(wm => wm.ChatId);
        }
    }
}