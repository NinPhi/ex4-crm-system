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
}
