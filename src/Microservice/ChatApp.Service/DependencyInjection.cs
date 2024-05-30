using ChatApp.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace ChatApp.Service;

public static class DependencyInjection
{
    public static IServiceCollection AddServiceCollectionExtentions(this IServiceCollection services,
        string connectionString)
    {
        services.AddCommonServices(connectionString: connectionString);

        return services;
    }
}
