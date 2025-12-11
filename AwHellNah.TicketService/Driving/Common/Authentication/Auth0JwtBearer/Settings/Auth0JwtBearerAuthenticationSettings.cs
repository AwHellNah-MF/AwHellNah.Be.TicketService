namespace AwHellNah.TicketService.Driving.Common.Authentication.Auth0JwtBearer.Settings;

public record Auth0JwtBearerAuthenticationSettings
{
    public const string Scheme = "Auth0JwtBearer";
    
    public required string Authority { get; init; } 
    public required string ValidAudience { get; init; } 
}