using AwHellNah.TicketService.Domain.TicketAggregate.Entities;
using Frametux.Shared.Driven.NpgsqlPersistence;
using Microsoft.EntityFrameworkCore;

namespace AwHellNah.TicketService.Driven.Persistence;

public class PersistenceDbContext(DbContextOptions<PersistenceDbContext> options) : NpgsqlPersistenceDbContext(options)
{
    public required DbSet<Ticket> Tickets { get; init; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(PersistenceDbContext).Assembly);
    }
}