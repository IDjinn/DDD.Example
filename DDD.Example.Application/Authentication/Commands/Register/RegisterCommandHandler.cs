using DDD.Example.Application.Authentication.Common;
using DDD.Example.Application.Common.Interfaces;
using DDD.Example.Application.Domain.Users;
using ErrorOr;
using MediatR;

namespace DDD.Example.Application.Authentication.Commands.Register;

public class RegisterCommandHandler : IRequestHandler<RegisterCommand, ErrorOr<AuthResult>>
{
    private readonly IPasswordService _passwordService;
    private readonly IJwtTokenGenerator _tokenGenerator;

    public RegisterCommandHandler(IJwtTokenGenerator tokenGenerator, IPasswordService passwordService)
    {
        _tokenGenerator = tokenGenerator;
        _passwordService = passwordService;
    }

    public async Task<ErrorOr<AuthResult>> Handle(RegisterCommand request, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;

        var user = new User
        {
            Id = Guid.NewGuid(),
            FirstName = request.FirstName,
            LastName = request.LastName,
            Email = new Email(request.Email),
            Password = _passwordService.HashPassword(request.Password),
        };

        return new AuthResult
        {
            UserId = user.Id.ToString(),
            Token = _tokenGenerator.GenerateToken(user)
        };
    }
}