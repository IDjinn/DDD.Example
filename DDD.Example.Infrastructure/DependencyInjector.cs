using System.Text;
using DDD.Example.Application.Authentication.Common;
using DDD.Example.Application.Common.Interfaces;
using DDD.Example.Infrastructure.Authentication;
using DDD.Example.Infrastructure.Providers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using ICryptoProvider = DDD.Example.Application.Common.Interfaces.ICryptoProvider;

namespace DDD.Example.Infrastructure;

public static class DependencyInjector
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services,
        ConfigurationManager configuration)
    {
        services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
        services.AddSingleton<ICryptoProvider, CryptoProvider>();
        services.AddSingleton<IPasswordService, PasswordService>();


        services.AddAuth(configuration);
        return services;
    }

    private static IServiceCollection AddDatabase(this IServiceCollection services, ConfigurationManager configuration)
    {
        return services;
    }

    private static IServiceCollection AddAuth(this IServiceCollection services, ConfigurationManager configuration)
    {
        services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();

        var jwtSettings = new JwtSettings();
        configuration.Bind(JwtSettings.SectionName, jwtSettings);
        services.Configure<JwtSettings>(configuration.GetSection(JwtSettings.SectionName));
        services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();

        services.AddAuthentication(defaultScheme: JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options => options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = jwtSettings.Issuer,
                ValidAudience = jwtSettings.Audiance,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.Secret))
            });

        return services;
    }
}