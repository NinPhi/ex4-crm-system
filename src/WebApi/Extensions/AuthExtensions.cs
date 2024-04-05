using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;

namespace WebApi.Extensions;

public static class AuthExtensions
{
    public static async Task SignInAsync(
        this HttpContext httpContext,
        string nameIdentifier,
        string email,
        string role)
    {
        Claim[] claims =
        [
            new(ClaimTypes.NameIdentifier, nameIdentifier),
            new(ClaimTypes.Email, email),
            new(ClaimTypes.Role, role),
        ];

        var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
        var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

        await httpContext.SignInAsync(claimsPrincipal);
    }

    public static long GetCurrentUserId(this HttpContext httpContext)
    {
        var nameIdentifier = httpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

        bool success = long.TryParse(nameIdentifier, out long userId);

        if (success is false)
            throw new Exception("Could not parse user id from the name identifier claim.");

        return userId;
    }
}
