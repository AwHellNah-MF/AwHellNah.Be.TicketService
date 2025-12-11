using Frametux.Shared.Core.Driving.MinimalApi;

namespace AwHellNah.TicketService.Driving;

public static class WebApplicationExt
{
    public static void UseDriving(this WebApplication app)
    {
        app.UseAuthentication();
        app.UseAuthorization();
        
        app.UseMinimalApis(typeof(Program).Assembly);
    }
}