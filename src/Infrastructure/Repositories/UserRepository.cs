
namespace Infrastructure.Repositories;

internal class UserRepository(AppDbContext dbContext) : IUserRepository
{
    public Task<User?> GetByEmailAsync(string email) =>
        dbContext.Users.AsNoTracking().FirstOrDefaultAsync(u => u.Email == email);

    public Task<List<User>> GetAllAsync() =>
        dbContext.Users.AsNoTracking().ToListAsync();
}
