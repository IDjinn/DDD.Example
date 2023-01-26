namespace DDD.Example.Application.Common.Interfaces;

public interface IPasswordService
{
    public Password HashPassword(string password);
    public bool CheckMatchRawPassword(Password password, string rawPassword);
}

public class Password
{
    public string Value { get; set; }
    public string Salt { get; set; }
}