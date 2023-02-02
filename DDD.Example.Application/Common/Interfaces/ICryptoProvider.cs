namespace DDD.Example.Application.Common.Interfaces;

public interface ICryptoProvider
{
    public SaltedHash HashAndSalt(string password, string? salt = null);
    public bool CheckMatchHash(string value, string hash);
    public byte[] Encrypt(byte[] value);

    public record SaltedHash(string Salt, string Hash);
}