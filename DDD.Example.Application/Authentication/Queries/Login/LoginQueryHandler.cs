using DDD.Example.Application.Authentication.Common;
using ErrorOr;
using MediatR;

namespace DDD.Example.Application.Authentication.Queries.Login;

public class LoginQueryHandler : IRequestHandler<LoginQuery, ErrorOr<AuthResult>>
{
    public async Task<ErrorOr<AuthResult>> Handle(LoginQuery request, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;

        return new AuthResult
        {
            UserId = Guid.NewGuid().ToString(),
            Token = Guid.NewGuid().ToString()
        };
    }
}