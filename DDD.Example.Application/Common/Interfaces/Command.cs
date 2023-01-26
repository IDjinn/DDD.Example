using ErrorOr;

namespace DDD.Example.Application.Common.Interfaces;

public abstract class Command
{
    public abstract ErrorOr<bool> TryValidate();
}