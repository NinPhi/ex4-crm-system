namespace Infrastructure.Repositories;

internal class ContactRepository(AppDbContext dbContext)
    : IContactRepository
{
    public Task<List<Contact>> GetAllAsync() =>
        dbContext.Contacts.AsNoTracking().ToListAsync();
}
