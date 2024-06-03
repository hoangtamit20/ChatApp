using ChatApp.Repository.Data.FluentApiConfigs;
using ChatApp.Repository.Entities.Chat;
using ChatApp.Repository.Entities.User;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ChatApp.Repository.Data
{
    public class ChatAppDbContext : IdentityDbContext<UserEntity>
    {
        public ChatAppDbContext(DbContextOptions<ChatAppDbContext> options) : base(options) { }

        #region db set
        public DbSet<ChatEntity> ChatEntities { get; set; }
        public DbSet<GroupChatMemberEntity> GroupChatMemberEntities { get; set; }
        public DbSet<MessageEntity> MessageEntities { get; set; }
        public DbSet<MessageFileEntity> MessageFileEntities { get; set; }
        public DbSet<WaitingMessageChatEntity> WaitingMessageChatEntities { get; set; }
        #endregion db set


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new ChatEntityConfiguration());
            builder.ApplyConfiguration(new MessageEntityConfiguration());
            builder.ApplyConfiguration(new MessageFileEntityConfiguration());
            builder.ApplyConfiguration(new GroupChatMemberEntityConfiguration());
            builder.ApplyConfiguration(new WaitingMessageChatEntityConfiguration());


            foreach (var entityType in builder.Model.GetEntityTypes())
                if (entityType.GetTableName()!.StartsWith("AspNet"))
                    entityType.SetTableName($"User_{entityType.GetTableName()!.Substring(6)}");
        }
    }
}