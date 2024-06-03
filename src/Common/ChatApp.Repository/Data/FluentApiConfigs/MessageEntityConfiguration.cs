using ChatApp.Repository.Constants;
using ChatApp.Repository.Entities.Chat;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ChatApp.Repository.Data.FluentApiConfigs
{
    public class MessageEntityConfiguration : IEntityTypeConfiguration<MessageEntity>
    {
        public void Configure(EntityTypeBuilder<MessageEntity> entity)
        {
            entity.ToTable(name: DatabaseConstant.MESSAGE_TABLE_NAME);
            entity.HasKey(message => message.Id);

            entity.Property(message => message.Content)
                   .IsRequired();

            entity.Property(message => message.IsIncludeFile)
                   .IsRequired();

            entity.Property(message => message.SendDate)
                   .IsRequired();

            entity.HasOne(message => message.Sender)
                   .WithMany(user => user.Messages)
                   .HasForeignKey(message => message.SenderId)
                   .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(message => message.Chat)
                   .WithMany(chat => chat.Messages)
                   .HasForeignKey(message => message.ChatId)
                   .OnDelete(DeleteBehavior.Restrict);

            entity.HasMany(message => message.MessageFiles)
                   .WithOne(messageFile => messageFile.Message)
                   .HasForeignKey(messageFile => messageFile.MessageId);

            entity.HasIndex(message => message.SenderId);
            entity.HasIndex(message => message.ChatId);
        }
    }
}