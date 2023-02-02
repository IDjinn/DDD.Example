namespace DDD.Example.Application.Domain.Common.Models;

public abstract class AggregateRoot<TId> : Entity<TId> where TId : notnull
{
}