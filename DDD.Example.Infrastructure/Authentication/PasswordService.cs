using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using DDD.Example.Application.Common.Interfaces;
using DDD.Example.Application.Domain.Users;

namespace DDD.Example.Infrastructure.Authentication;

public class PasswordService : IPasswordService
{
    private const string PEPPER = "#4M(QLS?h23eCjjW,im]95?m_:Z%qqQ5q$?c%#f]XkEHAihaN(P!.LNrZ%/Lm#@)";
    private readonly ICryptoProvider _cryptoProvider;

    public PasswordService(ICryptoProvider cryptoProvider)
    {
        _cryptoProvider = cryptoProvider;
    }

    public Application.Domain.Users.Password HashPassword(string password)
    {
        var safePassword = Convert.ToBase64String(Encoding.UTF8.GetBytes(password));
        var encryptedWithPepperPassword =
            Convert.ToBase64String(_cryptoProvider.Encrypt(Encoding.UTF8.GetBytes(safePassword + PEPPER)));
        var (salt, hash) = _cryptoProvider.HashAndSalt(encryptedWithPepperPassword);
        return new Password { Value = hash, Salt = salt };
    }

    public bool CheckMatchRawPassword(Password password, string rawPassword)
    {
        var safeRawPassword = Convert.ToBase64String(Encoding.UTF8.GetBytes(rawPassword));
        var encryptedRawSafeWithPepperPassword =
            Convert.ToBase64String(_cryptoProvider.Encrypt(Encoding.UTF8.GetBytes(safeRawPassword + PEPPER)));
        var (salt, hashedRawPassword) = _cryptoProvider.HashAndSalt(encryptedRawSafeWithPepperPassword, password.Salt);
        return safe_string_equals(hashedRawPassword, password.Value);
    }

    [MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
    private static bool safe_string_equals(string left, string right)
    {
        return CryptographicOperations.FixedTimeEquals(
            Encoding.UTF8.GetBytes(left),
            Encoding.UTF8.GetBytes(right)
        );
    }
}