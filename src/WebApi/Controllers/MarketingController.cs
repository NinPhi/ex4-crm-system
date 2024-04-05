using Application.Contracts.Contacts;
using Application.Features.Contacts.CreateNewContact;
using Application.Features.Contacts.GetAllContacts;

namespace WebApi.Controllers;

[ApiController]
[Route("api/marketing")]
public class MarketingController(ISender sender) : ControllerBase
{
    [Authorize(Roles = $"{nameof(Role.Admin)}, {nameof(Role.Marketing)}")]
    [HttpGet("contacts")]
    public async Task<IActionResult> GetAllContacts()
    {
        var query = new GetAllContactsQuery();

        var response = await sender.Send(query);

        return Ok(response);
    }

    [Authorize(Roles = nameof(Role.Marketing))]
    [HttpPost("contacts")]
    public async Task<IActionResult> CreateNewContact(
        CreateNewContactRequest request)
    {
        var currentUserId = HttpContext.GetCurrentUserId();

        var command = new CreateNewContactCommand(
            MarketerId: currentUserId,
            Data: request);

        var response = await sender.Send(command);

        return Ok(response);
    }
}
