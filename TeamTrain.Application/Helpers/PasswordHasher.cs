namespace TeamTrain.Application.Helpers;

public static class PasswordHasher
{
    public static string HashPassword(string password)
        => BCrypt.Net.BCrypt.HashPassword(password);

    public static bool VerifyPasswordHash(string password, string storedHash)
        => BCrypt.Net.BCrypt.Verify(password, storedHash);
}