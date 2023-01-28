using ErrorOr;

namespace DDD.Example.Application.Domain.Common.Errors;

public static partial class Errors
{
    public static class Authentication
    {
        public static Error InvalidCredentials = Error.Conflict(
            code: "Authentication.InvalidCredentials",
            description: "Invalid credentials were used. Try again."
        );

        public static Error InvalidIdentity = Error.Validation(
            code: "Authentication.InvalidIdentity",
            description: "Identity must be a phone number or email."
        );
    }
}