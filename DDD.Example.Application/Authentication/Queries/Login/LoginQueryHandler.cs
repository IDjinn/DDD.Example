using DDD.Example.Application.Authentication.Common;
using DDD.Example.Application.Domain.Users;
using ErrorOr;
using MediatR;

namespace DDD.Example.Application.Authentication.Queries.Login;

public class LoginQueryHandler : IRequestHandler<LoginQuery, ErrorOr<AuthResult>>
{
    private readonly IJwtTokenGenerator _tokenGenerator;

    public LoginQueryHandler(IJwtTokenGenerator tokenGenerator)
    {
        _tokenGenerator = tokenGenerator;
    }

    public async Task<ErrorOr<AuthResult>> Handle(LoginQuery request, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;

        var user = new User
        {
            Id = Guid.NewGuid(),
        };
        return new AuthResult
        {
            UserId = Guid.NewGuid().ToString(),
            Token = _tokenGenerator.GenerateToken(user)
        };
    }
}