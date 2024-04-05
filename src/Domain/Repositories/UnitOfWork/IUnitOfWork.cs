namespace Domain.Repositories.UnitOfWork;

public interface IUnitOfWork
{
    void SaveChanges();
    Task SaveChangesAsync();
}
