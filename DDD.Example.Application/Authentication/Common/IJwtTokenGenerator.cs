using DDD.Example.Application.Domain.Users;

namespace DDD.Example.Application.Authentication.Common;

public interface IJwtTokenGenerator
{
    public JwtToken GenerateToken(User user);
}