using Application.Features.Users.GetAllUsers;
using Domain.Enums;
using Microsoft.AspNetCore.Authorization;

namespace WebApi.Controllers;

[Authorize(Roles = nameof(Role.Admin))]
[ApiController]
[Route("api/admin")]
public class AdminController(ISender sender) : ControllerBase
{
    [HttpGet("users")]
    public async Task<IActionResult> GetAllUsers()
    {
        var request = new GetAllUsersQuery();

        var response = await sender.Send(request);

        return Ok(response);
    }
}
