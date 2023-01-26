namespace DDD.Example.Presentation.Contracts.Authentication;

public record LoginRequest(
    string Identity,
    string Password
);