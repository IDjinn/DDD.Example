namespace DDD.Example.Infrastructure.Authentication;

public class JwtSettings
{
    public const string SectionName = nameof(JwtSettings);

    public string Secret { get; init; } = null!;
    public int ExpirationMinutes { get; init; }
    public string Issuer { get; init; } = null!;
    public string Audiance { get; init; } = null!;
}