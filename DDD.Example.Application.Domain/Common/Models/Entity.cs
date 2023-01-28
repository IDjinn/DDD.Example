namespace DDD.Example.Application.Domain.Common.Models;

public abstract class Entity<TId> : IEquatable<Entity<TId>> where TId : notnull
{
    public Entity()
    {
    }

    public Entity(TId id)
    {
        Id = id;
    }

    public TId Id { get; protected init; }
    public DateTime CreatedAt { get; set; }
    public DateTime EditedAt { get; set; }

    public bool Equals(Entity<TId>? other)
    {
        return Equals((object?)other);
    }

    public override bool Equals(object? obj)
    {
        return obj is Entity<TId> otherEntity && Id.Equals(otherEntity.Id);
    }

    public static bool operator ==(Entity<TId>? left, Entity<TId>? right)
    {
        return Equals(left, right);
    }

    public static bool operator !=(Entity<TId>? left, Entity<TId>? right)
    {
        return !Equals(left, right);
    }

    public override int GetHashCode()
    {
        return Id.GetHashCode();
    }
}