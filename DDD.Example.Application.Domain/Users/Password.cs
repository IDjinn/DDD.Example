using DDD.Example.Application.Domain.Common.Models;

namespace DDD.Example.Application.Domain.Users;

public class Password : ValueObject
{
    public string Value { get; init; }
    public string Salt { get; set; }

    protected override IEnumerable<object?> GetEqualityComponents()
    {
        yield return Value;
        yield return Salt;
    }

    public override string ToString()
    {
        return Value;
    }
}