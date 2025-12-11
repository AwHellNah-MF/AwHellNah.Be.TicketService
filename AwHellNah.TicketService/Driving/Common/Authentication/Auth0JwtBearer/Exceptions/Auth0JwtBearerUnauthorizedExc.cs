namespace AwHellNah.TicketService.Driving.Common.Authentication.Auth0JwtBearer.Exceptions;

public class Auth0JwtBearerUnauthorizedExc : Exception
{
    public Auth0JwtBearerUnauthorizedExc()
    {
    }

    public Auth0JwtBearerUnauthorizedExc(string? message) : base(message)
    {
    }
}