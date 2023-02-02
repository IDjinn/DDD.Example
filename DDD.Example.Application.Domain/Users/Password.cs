using DDD.Example.Application.Domain.Common.Models;

namespace DDD.Example.Application.Domain.Users;

public sealed record Password(string Value, string Salt) : ValueObject
{
    public override string ToString()
    {
        return Value;
    }
}