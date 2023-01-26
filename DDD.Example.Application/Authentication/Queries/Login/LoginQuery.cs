using DDD.Example.Application.Authentication.Common;
using DDD.Example.Application.Common.Interfaces;
using ErrorOr;
using MediatR;

namespace DDD.Example.Application.Authentication.Queries.Login;

public class LoginQuery : Query, IRequest<ErrorOr<AuthResult>>
{
    public string Identity { get; init; }
    public string Password { get; init; }

    public override ErrorOr<bool> TryValidate()
    {
        return true;
    }
}