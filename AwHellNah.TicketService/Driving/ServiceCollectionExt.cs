using AwHellNah.TicketService.Driving.Common.Authentication.Auth0JwtBearer;
using AwHellNah.TicketService.Driving.V1.CreateTicket;

namespace AwHellNah.TicketService.Driving;

public static class ServiceCollectionExt
{
    public static void AddDriving(this IServiceCollection services)
    {
        services.AddHttpContextAccessor();
        services.AddAuthenticationAndAuthorization();
        
        services.AddScoped<SubmitTicketService>();
    }
    
    private static void AddAuthenticationAndAuthorization(this IServiceCollection services)
    {
        services.AddAuth0JwtBearerAuthentication();
        services.AddAuthorization();
    }
}