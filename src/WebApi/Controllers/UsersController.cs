using Application.Contracts.Users;
using Application.Features.Users.CreateNewUser;
using Application.Features.Users.EditUserBlock;
using Application.Features.Users.GetAllUsers;
using Application.Features.Users.SetUserRole;

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

    [HttpPatch("{id}/block")]
    public async Task<IActionResult> Block(long id)
    {
        var command = new EditUserBlockCommand(id, IsBlocked: true);

        var response = await sender.Send(command);

        if (response is false)
            return BadRequest($"User with ID {id} was not found.");

        return NoContent();
    }

    [HttpPatch("{id}/unblock")]
    public async Task<IActionResult> Unblock(long id)
    {
        var command = new EditUserBlockCommand(id, IsBlocked: false);

        var response = await sender.Send(command);

        if (response is false)
            return BadRequest($"User with ID {id} was not found.");

        return NoContent();
    }

    [HttpPatch("{id}/role")]
    public async Task<IActionResult> SetRole(long id, SetUserRoleRequest request)
    {
        var currentUserId = HttpContext.GetCurrentUserId();

        var command = new SetUserRoleCommand(
            CurrentUserId: currentUserId,
            TargetUserId: id,
            Role: request.Role);

        var response = await sender.Send(command);

        if (response is false)
            return BadRequest($"Failed to set role {request.Role} to user with ID {id}.");

        return NoContent();
    }
}
