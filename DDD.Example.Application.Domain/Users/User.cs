namespace DDD.Example.Application.Domain.Users;

public class User
{
    public Guid Id { get; init; }
    public string FirstName { get; init; } = null!;
    public string LastName { get; init; } = null!;
}