using Application.Services;
using static BCrypt.Net.BCrypt;

namespace Infrastructure.Services;

internal class PasswordManager : IPasswordManager
{
    public bool Validate(string password, string hash) => Verify(password, hash);
}
