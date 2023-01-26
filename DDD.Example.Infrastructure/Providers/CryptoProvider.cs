using System.Security.Cryptography;
using DDD.Example.Application.Common.Interfaces;
using BCryptor = BCrypt.Net.BCrypt;

namespace DDD.Example.Infrastructure.Providers;

public class CryptoProvider : ICryptoProvider
{
    private const int WORK_FACTOR = 12;

    public ICryptoProvider.SaltedHash HashAndSalt(string value, string? salt = null)
    {
        salt ??= BCryptor.GenerateSalt(WORK_FACTOR);
        var hash = BCryptor.HashPassword(value, salt);
        return new(salt, hash);
    }

    public bool CheckMatchHash(string value, string hash)
    {
        return BCryptor.Verify(value, hash);
    }

    public byte[] Encrypt(byte[] value)
    {
        using var sha = SHA384.Create();
        return sha.ComputeHash(value);
    }
}