namespace Domain.Repositories;

public interface IContactRepository
{
    Task<List<Contact>> GetAllAsync();
}
