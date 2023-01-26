using DDD.Example.Application.Authentication.Common;
using DDD.Example.Application.Common.Interfaces;
using ErrorOr;
using MediatR;

namespace DDD.Example.Application.Authentication.Commands.Register;

public class RegisterCommand : Command, IRequest<ErrorOr<AuthResult>>
{
    public string FirstName { get; init; }
    public string LastName { get; init; }
    public string Email { get; init; }
    public string Password { get; init; }

    public override ErrorOr<bool> TryValidate()
    {
        return true;
    }
}