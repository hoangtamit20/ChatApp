using ChatApp.Repository.BaseEntities;
using ChatApp.Repository.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

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

        services.AddIdentityCore<UserEntity>()
            .AddRoles<IdentityRole>()
            .AddEntityFrameworkStores<ChatAppDbContext>()
            .AddTokenProvider<DataProtectorTokenProvider<UserEntity>>(TokenOptions.DefaultProvider);

        return services;
    }
}