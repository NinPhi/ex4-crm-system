using Domain.Repositories.UnitOfWork;

namespace Infrastructure.Repositories.UnitOfWork;

internal class UnitOfWork(AppDbContext dbContext) : IUnitOfWork
{
    public void SaveChanges() => dbContext.SaveChanges();

    public Task SaveChangesAsync() => dbContext.SaveChangesAsync();
}
