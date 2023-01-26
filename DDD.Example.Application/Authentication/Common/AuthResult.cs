namespace DDD.Example.Application.Authentication.Common;

public record struct AuthResult(
    string UserId,
    string Token
);