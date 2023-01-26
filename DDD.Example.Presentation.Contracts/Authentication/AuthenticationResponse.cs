using DDD.Example.Application.Authentication.Common;

namespace DDD.Example.Presentation.Contracts.Authentication;

public record struct AuthenticationResponse(
    string UserId,
    string Token
)
{
    public static implicit operator AuthenticationResponse(AuthResult result)
    {
        return new AuthenticationResponse
        {
            UserId = result.UserId,
            Token = result.Token
        };
    }
}