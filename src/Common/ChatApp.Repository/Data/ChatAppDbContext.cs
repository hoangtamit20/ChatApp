using ChatApp.Repository.Entities.User;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ChatApp.Repository.Data
{
    public class ChatAppDbContext : IdentityDbContext<UserEntity>
    {
        public ChatAppDbContext(DbContextOptions<ChatAppDbContext> options) : base(options) { }

        #region db set


        #endregion db set


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}