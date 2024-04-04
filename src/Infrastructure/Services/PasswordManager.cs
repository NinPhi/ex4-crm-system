using Application.Services;

namespace Infrastructure.Services;

internal class PasswordManager : IPasswordManager
{
    private const int WORK_FACTOR = 12;

    public bool VerifyPassword(string password, string hash) =>
        BCrypt.Net.BCrypt.Verify(password, hash);

    public string HashPassword(string password) =>
        BCrypt.Net.BCrypt.HashPassword(password, WORK_FACTOR);
}
