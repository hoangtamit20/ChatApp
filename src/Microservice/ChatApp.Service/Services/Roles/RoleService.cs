using ChatApp.Repository.Entities.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;

namespace ChatApp.Service.Services.Roles
{
    public class RoleService : IRoleService
    {
        private readonly UserManager<UserEntity> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ILogger<RoleService> _logger;

        public RoleService(UserManager<UserEntity> userManager,
            RoleManager<IdentityRole> roleManager,
            ILogger<RoleService> logger)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _logger = logger;
        }


        
    }
}