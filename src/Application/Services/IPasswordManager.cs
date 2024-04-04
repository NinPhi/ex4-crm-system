namespace Application.Services;

public interface IPasswordManager
{
    bool Validate(string password);
}
