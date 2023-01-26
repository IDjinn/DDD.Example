using DDD.Example.Application.Authentication.Common;
using DDD.Example.Application.Domain.Users;
using ErrorOr;
using MediatR;

namespace DDD.Example.Application.Authentication.Commands.Register;

public class RegisterCommandHandler : IRequestHandler<RegisterCommand, ErrorOr<AuthResult>>
{
    private readonly IJwtTokenGenerator _tokenGenerator;

    public RegisterCommandHandler(IJwtTokenGenerator tokenGenerator)
    {
        _tokenGenerator = tokenGenerator;
    }

    public async Task<ErrorOr<AuthResult>> Handle(RegisterCommand request, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;

        var user = new User
        {
            Id = Guid.NewGuid(),
            FirstName = request.FirstName,
            LastName = request.LastName
        };
        return new AuthResult
        {
            UserId = user.Id.ToString(),
            Token = _tokenGenerator.GenerateToken(user)
        };
    }
}