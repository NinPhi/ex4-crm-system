using Application.Contracts.Contacts;

namespace Application.Features.Contacts.GetAllContacts;

public record GetAllContactsQuery : IRequest<List<ContactResponse>>;