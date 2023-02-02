using DDD.Example.Application.Authentication.Common;
using DDD.Example.Application.Common.Extensions;
using DDD.Example.Application.Common.Interfaces;
using DDD.Example.Application.Domain.Common.Errors;
using ErrorOr;
using Flunt.Br;
using Flunt.Br.Extensions;
using MediatR;

namespace DDD.Example.Application.Authentication.Queries.Login;

public record LoginQuery : Query, IRequest<ErrorOr<AuthResult>>
{
    public string Identity { get; init; } = null!;
    public string Password { get; init; } = null!;

    public override ErrorOr<bool> TryValidate()
    {
        var isPhone = new Contract().IsPhone(Identity, nameof(Identity), "Phone is not valid.").IsValid;
        var isEmail = new Contract().IsEmail(Identity, nameof(Identity)).IsValid;
        if (!isPhone && !isEmail)
            return Errors.Authentication.InvalidIdentity;

        var contract = new Contract()
            .IsGreaterOrEqualsThan(Password, AuthSettings.Password.MinLenght, nameof(Password))
            .IsLowerOrEqualsThan(Password, AuthSettings.Password.MaxLenght, nameof(Password));

        if (contract.IsValid)
            return true;

        return contract.Notifications.ToErrorOr<bool>();
    }
}