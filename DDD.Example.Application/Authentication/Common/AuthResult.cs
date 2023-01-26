namespace DDD.Example.Application.Authentication.Common;

public readonly record struct AuthResult(
    string UserId,
    JwtToken Token
);