using Application.Contracts.Contacts;

namespace Application.Features.Contacts.CreateNewContact;

internal sealed class CreateNewContactHandler(
    IContactRepository contactRepository,
    IUnitOfWork unitOfWork)
    : IRequestHandler<CreateNewContactCommand, ContactResponse>
{
    public async Task<ContactResponse> Handle(
        CreateNewContactCommand request, CancellationToken cancellationToken)
    {
        var contact = request.Data.Adapt<Contact>();

        contact.MarketerId = request.MarketerId;

        contactRepository.AddNew(contact);

        await unitOfWork.SaveChangesAsync();

        var response = contact.Adapt<ContactResponse>();

        return response;
    }
}
