using ChatApp.Repository.Constants;
using ChatApp.Repository.Entities.Chat;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ChatApp.Repository.Data.FluentApiConfigs
{
    public class ChatEntityConfiguration : IEntityTypeConfiguration<ChatEntity>
    {
        public void Configure(EntityTypeBuilder<ChatEntity> entity)
        {
            entity.ToTable(name: DatabaseConstant.CHAT_TABLE_NAME);

            entity.HasKey(chat => chat.Id);

            entity.HasIndex(chat => chat.Name);

            entity.Property(chat => chat.Name)
                .HasMaxLength(maxLength: 100)
                .IsRequired();

            entity.Property(chat => chat.Type)
                   .HasConversion<int>()
                   .IsRequired();

            entity.Property(chat => chat.TotalMember)
                   .IsRequired();

            entity.Property(chat => chat.MaximumMember)
                   .IsRequired();

            entity.Property(chat => chat.CreateDate)
                   .IsRequired();

            entity.HasMany(chat => chat.Messages)
                   .WithOne(message => message.Chat)
                   .HasForeignKey(message => message.ChatId);

            entity.HasMany(chat => chat.GroupChatMembers)
                   .WithOne(member => member.Chat)
                   .HasForeignKey(member => member.ChatId);
        }
    }
}