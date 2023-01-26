namespace DDD.Example.Presentation.WebAPI;

public static class DependencyInjector
{
    public static IServiceCollection AddPresentation(this IServiceCollection services,
        ConfigurationManager builderConfiguration)
    {
        return services;
    }
}