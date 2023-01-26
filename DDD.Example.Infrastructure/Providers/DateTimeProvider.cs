using DDD.Example.Application.Common.Interfaces;

namespace DDD.Example.Infrastructure.Providers;

public class DateTimeProvider : IDateTimeProvider
{
    public DateTime UtcNow => DateTime.UtcNow;
}