using AwHellNah.TicketService.Driven.Persistence;
using Frametux.Shared.Driven.NpgsqlPersistence;

namespace AwHellNah.TicketService.Driven;

public static class ServiceCollectionExt
{
    public static void AddDriven(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddNpgsqlPersistence<PersistenceDbContext>(configuration);
    }
}