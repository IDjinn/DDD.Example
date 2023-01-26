using DDD.Example.Application.Authentication.Common;
using ErrorOr;
using MediatR;

namespace DDD.Example.Application.Authentication.Commands.Register;

public class RegisterCommandHandler : IRequestHandler<RegisterCommand, ErrorOr<AuthResult>>
{
    public async Task<ErrorOr<AuthResult>> Handle(RegisterCommand request, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;

        return new AuthResult
        {
            UserId = Guid.NewGuid().ToString(),
            Token = Guid.NewGuid().ToString()
        };
    }
}