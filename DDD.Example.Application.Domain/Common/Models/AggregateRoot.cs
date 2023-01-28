namespace DDD.Example.Application.Domain.Common.Models;

public class AggregateRoot<TId> : Entity<TId> where TId : notnull
{
}