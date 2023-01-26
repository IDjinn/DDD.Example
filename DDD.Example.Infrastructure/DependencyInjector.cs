using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DDD.Example.Infrastructure;

public static class DependencyInjector
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services,
        ConfigurationManager configuration)
    {
        return services;
    }

    private static IServiceCollection AddDatabase(this IServiceCollection services, ConfigurationManager configuration)
    {
        return services;
    }

    private static IServiceCollection AddAuth(this IServiceCollection services, ConfigurationManager configuration)
    {
        return services;
    }
}