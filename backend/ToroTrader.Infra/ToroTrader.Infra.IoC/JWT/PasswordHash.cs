using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.Security.Cryptography;
using System.Text;
using ToroTrader.Application.Domain.Structure.JWT;

namespace ToroTrader.Infra.IoC.JWT;

public class PasswordHash : IPasswordHash
{
    public string EncryptPassword(string password, string passwordHash)
    {
        string encryptedPassw = Convert.ToBase64String(KeyDerivation.Pbkdf2(
            password: password,
            salt: Encoding.UTF8.GetBytes(passwordHash),
            prf: KeyDerivationPrf.HMACSHA512,
            iterationCount: 10000,
            numBytesRequested: 256 / 8
        ));
        return encryptedPassw;
    }

    public bool PasswordIsEquals(string enteredPassword, string passwordHash, string storedPassword)
    {
        string encryptedPassw = Convert.ToBase64String(KeyDerivation.Pbkdf2(
            password: enteredPassword,
            salt: Encoding.UTF8.GetBytes(passwordHash),
            prf: KeyDerivationPrf.HMACSHA512,
            iterationCount: 10000,
            numBytesRequested: 256 / 8
        ));
        return encryptedPassw == storedPassword;
    }


    public string GeneratePasswordHash()
    {
        byte[] salt = new byte[256 / 8];
        using (var rng = RandomNumberGenerator.Create())
        {
            rng.GetBytes(salt);
        }
        return Convert.ToBase64String(salt);
    }
}