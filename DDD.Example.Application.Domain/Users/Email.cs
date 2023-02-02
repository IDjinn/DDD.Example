using DDD.Example.Application.Domain.Common.Models;

namespace DDD.Example.Application.Domain.Users;

public sealed record Email(string Value) : ValueObject
{
    public override string ToString()
    {
        return Value;
    }
}