using ErrorOr;
using Flunt.Notifications;

namespace DDD.Example.Application.Common.Extensions;

public static class FluntExtensions
{
    public static ErrorOr<T> ToErrorOr<T>(this IReadOnlyCollection<Notification> notifications)
    {
        return ErrorOr<T>.From(notifications
            .Select(notification => Error.Validation(notification.Key, notification.Message)).ToList());
    }
}