using Application.Contracts.Contacts;

namespace Application.Features.Contacts;

internal sealed class GetAllContactsHandler(IContactRepository contactRepository)
    : IRequestHandler<GetAllContactsQuery, List<ContactResponse>>
{
    public async Task<List<ContactResponse>> Handle(
        GetAllContactsQuery request, CancellationToken cancellationToken)
    {
        var contacts = await contactRepository.GetAllAsync();

        var response = contacts.Adapt<List<ContactResponse>>();

        return response;
    }
}
