using AwHellNah.TicketService.Domain.TicketAggregate.Entities;
using AwHellNah.TicketService.Domain.TicketAggregate.ValueObjs;
using AwHellNah.TicketService.Driven.Persistence;
using Frametux.Shared.Core.Domain.ValueObjs;

namespace AwHellNah.TicketService.Domain.TicketAggregate.Services;

public interface ITicketsService
{
    Task<Ticket> CreateTicketAsync(
        TicketTitle title,
        TicketDescription? description,
        Id creatorUserId,
        CancellationToken cancellationToken);
}

public record TicketsService(PersistenceDbContext DbContext) : ITicketsService
{
    public async Task<Ticket> CreateTicketAsync(
        TicketTitle title,
        TicketDescription? description,
        Id creatorUserId,
        CancellationToken cancellationToken)
    {
        var newTicket = new Ticket
        {
            Title = title,
            Description = description,
            CreatorUserId = creatorUserId
        };
        
        await DbContext.Tickets.AddAsync(newTicket, cancellationToken);

        return newTicket;
    }
}