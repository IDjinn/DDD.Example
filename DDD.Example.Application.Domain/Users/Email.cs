using DDD.Example.Application.Domain.Common.Models;

namespace DDD.Example.Application.Domain.Users;

public class Email : ValueObject
{
    public Email(string email)
    {
        Value = email;
    }

    public string Value { get; init; }

    protected override IEnumerable<object?> GetEqualityComponents()
    {
        yield return Value;
    }

    public override string ToString()
    {
        return Value;
    }
}