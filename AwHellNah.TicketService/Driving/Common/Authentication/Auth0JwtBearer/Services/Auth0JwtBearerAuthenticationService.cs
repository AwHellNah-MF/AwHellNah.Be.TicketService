using System.Security.Claims;
using AwHellNah.TicketService.Driving.Common.Authentication.Auth0JwtBearer.Exceptions;

namespace AwHellNah.TicketService.Driving.Common.Authentication.Auth0JwtBearer.Services;

public interface IAuth0JwtBearerAuthenticationService
{
    public string? GetCurrentUserId();
    public string GetCurrentUserIdOrThrow();
}

public class Auth0JwtBearerAuthenticationService(IHttpContextAccessor httpContextAccessor) : IAuth0JwtBearerAuthenticationService
{
    public string? GetCurrentUserId()
    {
        var user = httpContextAccessor.HttpContext?.User;
        return user?.FindFirstValue(ClaimTypes.NameIdentifier);
    }
    
    public string GetCurrentUserIdOrThrow() 
        => GetCurrentUserId() 
           ?? throw new Auth0JwtBearerUnauthorizedExc("User is not authenticated or missing User Id in the token.");
}