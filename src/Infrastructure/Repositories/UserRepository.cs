
using Domain.Enums;

namespace Infrastructure.Repositories;

internal class UserRepository(AppDbContext dbContext) : IUserRepository
{
    public Task<User?> GetByEmailAsync(string email) =>
        dbContext.Users.AsNoTracking().FirstOrDefaultAsync(u => u.Email == email);

    public Task<List<User>> GetAllAsync() =>
        dbContext.Users.AsNoTracking().ToListAsync();

    public Task<bool> EmailExistsAsync(string email) =>
        dbContext.Users.AnyAsync(u => u.Email == email);

    public void AddNew(User user) => dbContext.Users.Add(user);

    public async Task<bool> BlockAsync(long id)
    {
        var user = await dbContext.Users.FindAsync(id);

        if (user is null) return false;

        user.BlockedOn = DateTime.UtcNow;

        return true;
    }

    public async Task<bool> UnblockAsync(long id)
    {
        var user = await dbContext.Users.FindAsync(id);

        if (user is null) return false;

        user.BlockedOn = null;

        return true;
    }

    public async Task<bool> SetRoleAsync(long id, Role role)
    {
        var user = await dbContext.Users.FindAsync(id);

        if (user is null) return false;

        user.Role = role;

        return true;
    }
}
