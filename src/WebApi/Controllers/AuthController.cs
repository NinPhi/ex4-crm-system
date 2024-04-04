using Application.Features.Auth.SignIn;
using Mapster;
using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using WebApi.Contracts;
using WebApi.Extensions;

namespace WebApi.Controllers;

[ApiController]
[Route("api/auth")]
public class AuthController(ISender sender) : ControllerBase
{
    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginData data)
    {
        var request = data.Adapt<SignInRequest>();

        var response = await sender.Send(request);

        if (response is null)
            return Unauthorized("User credentials are invalid " +
                "or the user was blocked by administrators.");

        await HttpContext.SignInAsync(
            response.Id.ToString(),
            response.Email,
            response.Role.ToString());

        return NoContent();
    }
}
