using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DDD.Example.Application;

public static class DependencyInjector
{
    public static IServiceCollection AddApplication(this IServiceCollection services,
        ConfigurationManager configuration)
    {
        services.AddMediatR(typeof(DependencyInjector).Assembly);
        return services;
    }
}