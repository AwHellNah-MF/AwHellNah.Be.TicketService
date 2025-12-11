using AwHellNah.TicketService.Domain.TicketAggregate.ValueObjs;
using Frametux.Shared.Core.Domain.Entities;
using Frametux.Shared.Core.Domain.ValueObjs;

namespace AwHellNah.TicketService.Domain.TicketAggregate.Entities;

public class Ticket : BaseEntity
{
    public required TicketTitle Title { get; set; }
    public TicketDescription? Description { get; set; }
    public required Id CreatorUserId { get; init; }
}