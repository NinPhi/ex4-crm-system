using Application.Contracts.Contacts;

namespace Application.Features.Contacts.CreateNewContact;

public record CreateNewContactCommand(
    long MarketerId, CreateNewContactRequest Data)
    : IRequest<ContactResponse>;