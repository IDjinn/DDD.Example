namespace DDD.Example.Application.Domain.Users;

public class User
{
    public Guid Id { get; init; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public Email Email { get; set; } = null!;
    public Password Password { get; set; } = null!;
}