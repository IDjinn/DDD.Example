using DDD.Example.Application.Authentication.Commands.Register;

namespace DDD.Example.Presentation.Contracts.Authentication;

public record RegisterRequest(
    string FirstName,
    string LastName,
    string Email,
    string Password
)
{
    public static explicit operator RegisterCommand(RegisterRequest request)
    {
        return new RegisterCommand
        {
            FirstName = request.FirstName,
            LastName = request.LastName,
            Email = request.Email,
            Password = request.Password
        };
    }
}