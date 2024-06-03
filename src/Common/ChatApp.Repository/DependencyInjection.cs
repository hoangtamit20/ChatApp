using ChatApp.Repository.Entities.User;
using ChatApp.Repository.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ChatApp.Repository.Repositories;

namespace ChatApp.Repository;

public static class DependencyInjection
{
    public static IServiceCollection AddCommonServices(this IServiceCollection services,
        string connectionString)
    {
        services.AddDbContextFactory<ChatAppDbContext>(options =>
        {
            options.UseSqlServer(connectionString: connectionString);
        });

        services.AddScoped<ChatAppDbContext>(options =>
            options.GetRequiredService<IDbContextFactory<ChatAppDbContext>>()
                .CreateDbContext()
        );

        services.AddDataProtection();

        services.AddIdentity<UserEntity, IdentityRole>()
            .AddDefaultTokenProviders()
            .AddEntityFrameworkStores<ChatAppDbContext>()
            .AddRoles<IdentityRole>();


        services.AddScoped<IDbRepository, DbRepository>();

        return services;
    }
}