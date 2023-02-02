using DDD.Example.Application.Authentication.Common;
using DDD.Example.Application.Common.Extensions;
using DDD.Example.Application.Common.Interfaces;
using ErrorOr;
using Flunt.Br;
using MediatR;

namespace DDD.Example.Application.Authentication.Commands.Register;

public record RegisterCommand : Command, IRequest<ErrorOr<AuthResult>>
{
    public string FirstName { get; init; } = null!;
    public string LastName { get; init; } = null!;
    public string Email { get; init; } = null!;
    public string Password { get; init; } = null!;

    public override ErrorOr<bool> TryValidate()
    {
        var contract = new Contract()
            .Requires()
            .IsGreaterThan(FirstName, 3, nameof(FirstName))
            .IsLowerOrEqualsThan(FirstName, 20, nameof(FirstName))
            .IsGreaterThan(LastName, 3, nameof(LastName))
            .IsLowerOrEqualsThan(LastName, 20, nameof(LastName))
            .IsGreaterOrEqualsThan(Password, AuthSettings.Password.MinLenght, nameof(Password))
            .IsLowerOrEqualsThan(Password, AuthSettings.Password.MaxLenght, nameof(Password))
            .IsEmail(Email, nameof(Email));

        if (contract.IsValid)
            return true;

        return contract.Notifications.ToErrorOr<bool>();
    }
}