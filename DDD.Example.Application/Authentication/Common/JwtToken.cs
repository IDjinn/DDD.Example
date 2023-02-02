namespace DDD.Example.Application.Authentication.Common;

public sealed record JwtToken(string Value)
{
    public override string ToString()
    {
        return Value;
    }
}