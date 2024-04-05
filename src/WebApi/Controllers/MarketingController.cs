using Application.Features.Contacts;

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
}
