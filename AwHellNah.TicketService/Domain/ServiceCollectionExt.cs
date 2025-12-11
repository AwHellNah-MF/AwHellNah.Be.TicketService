using AwHellNah.TicketService.Domain.TicketAggregate.Services;

namespace AwHellNah.TicketService.Domain;

public static class ServiceCollectionExt
{
    public static void AddDomain(this IServiceCollection services)
    {
        services.AddScoped<ITicketsService, TicketsService>();
    }
}