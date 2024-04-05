using Application.Contracts.Contacts;

namespace Application.Features.Contacts;

public record GetAllContactsQuery : IRequest<List<ContactResponse>>;