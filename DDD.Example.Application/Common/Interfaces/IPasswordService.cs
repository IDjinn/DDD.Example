using DDD.Example.Application.Domain.Users;

namespace DDD.Example.Application.Common.Interfaces;

public interface IPasswordService
{
    public Password HashPassword(string password);
    public bool CheckMatchRawPassword(Password password, string rawPassword);
}