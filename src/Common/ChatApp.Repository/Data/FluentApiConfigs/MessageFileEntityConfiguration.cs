using ChatApp.Repository.Constants;
using ChatApp.Repository.Entities.Chat;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ChatApp.Repository.Data.FluentApiConfigs
{
    public class MessageFileEntityConfiguration : IEntityTypeConfiguration<MessageFileEntity>
    {
        public void Configure(EntityTypeBuilder<MessageFileEntity> entity)
        {
            entity.ToTable(name: DatabaseConstant.MESSAGE_FILE_TABLE_NAME);
            entity.HasKey(mf => mf.Id);

            entity.Property(mf => mf.Url)
                .HasMaxLength(maxLength: 3000)
                .IsRequired();

            entity.Property(mf => mf.FileName)
                .HasMaxLength(maxLength: 100)
                .IsRequired();

            entity.Property(mf => mf.BlobName)
                .HasMaxLength(maxLength: 100)
                .IsRequired();

            entity.Property(mf => mf.Type)
                .HasConversion<int>()
                .IsRequired();

            entity.HasOne(mf => mf.Message)
                .WithMany(message => message.MessageFiles)
                .HasForeignKey(mf => mf.MessageId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasIndex(mf => mf.MessageId);
        }
    }
}