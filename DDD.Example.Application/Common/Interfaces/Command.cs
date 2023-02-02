using ErrorOr;

namespace DDD.Example.Application.Common.Interfaces;

public abstract record Command
{
    public abstract ErrorOr<bool> TryValidate();
}