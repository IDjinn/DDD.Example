using DDD.Example.Application.Authentication.Queries.Login;

namespace DDD.Example.Presentation.Contracts.Authentication;

public readonly record struct LoginRequest(
    string Identity,
    string Password
)
{
    public static explicit operator LoginQuery(LoginRequest request)
    {
        return new LoginQuery
        {
            Identity = request.Identity,
            Password = request.Password
        };
    }
}