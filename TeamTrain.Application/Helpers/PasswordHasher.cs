using System.Security.Cryptography;
using System.Text;

namespace TeamTrain.Application.Helpers;

public static class PasswordHasher
{
    public static string HashPassword(string password)
    {
        using var hmac = new HMACSHA512();
        var hashBytes = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
        return Convert.ToBase64String(hashBytes);
    }

    public static bool VerifyPasswordHash(string password, string storedHash)
    {
        using var hmac = new HMACSHA512();
        var hashBytes = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
        return storedHash == Convert.ToBase64String(hashBytes);
    }
}