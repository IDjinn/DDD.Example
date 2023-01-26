namespace DDD.Example.Application.Authentication.Common;

public readonly record struct JwtToken(string Value)
{
    public override string ToString()
    {
        return Value;
    }
}