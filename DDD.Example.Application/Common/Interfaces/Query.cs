using ErrorOr;

namespace DDD.Example.Application.Common.Interfaces;

public abstract class Query
{
    public abstract ErrorOr<bool> TryValidate();
}