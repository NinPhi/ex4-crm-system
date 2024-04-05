using Domain.Enums;

namespace Domain.Repositories;

public interface IUserRepository
{
    Task<User?> GetByEmailAsync(string email);
    Task<List<User>> GetAllAsync();
    Task<bool> EmailExistsAsync(string email);
    void AddNew(User user);
    Task<bool> BlockAsync(long id);
    Task<bool> UnblockAsync(long id);
    Task<bool> SetRoleAsync(long id, Role role);
}
