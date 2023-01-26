namespace DDD.Example.Presentation.WebAPI;

public static class DependencyInjector
{
    public static IServiceCollection AddPresentation(
        this IServiceCollection services,
        ConfigurationManager builderConfiguration
    )
    {
        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        return services;
    }

    public static void SetupSwagger(this WebApplication app)
    {
        if (!app.Environment.IsDevelopment()) return;

        app.UseSwagger();
        app.UseSwaggerUI();
    }
}