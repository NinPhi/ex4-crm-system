using Application.Contracts.Users;
using Application.Features.Users.CreateNewUser;
using Application.Features.Users.GetAllUsers;
using Domain.Enums;
using Microsoft.AspNetCore.Authorization;

namespace WebApi.Controllers;

[Authorize(Roles = nameof(Role.Admin))]
[ApiController]
[Route("api/users")]
public class UsersController(ISender sender) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var query = new GetAllUsersQuery();

        var response = await sender.Send(query);

        return Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult> CreateNew(NewUserRequest request)
    {
        var command = request.Adapt<CreateNewUserCommand>();

        var response = await sender.Send(command);

        if (response is null)
            return BadRequest($"Email {request.Email} is already taken.");

        return Ok(response);
    }
}
