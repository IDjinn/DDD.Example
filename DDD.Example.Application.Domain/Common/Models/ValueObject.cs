namespace DDD.Example.Application.Domain.Common.Models;

public abstract class ValueObject : IEquatable<ValueObject>
{
    #region EQUALITY_STUFF

    protected abstract IEnumerable<object?> GetEqualityComponents();

    public override bool Equals(object? obj)
    {
        return obj is ValueObject valueObject && Equals(valueObject);
    }

    public bool Equals(ValueObject? other)
    {
        return other is not null && GetEqualityComponents().SequenceEqual(other.GetEqualityComponents());
    }

    public static bool operator ==(ValueObject? left, ValueObject? right)
    {
        return Equals(left, right);
    }

    public static bool operator !=(ValueObject? left, ValueObject? right)
    {
        return !Equals(left, right);
    }

    public override int GetHashCode()
    {
        var hashCode = new HashCode();
        foreach (var hash in GetEqualityComponents().Select(x => x?.GetHashCode() ?? 0)) hashCode.Add(hash);
        return hashCode.ToHashCode();
    }

    #endregion
}