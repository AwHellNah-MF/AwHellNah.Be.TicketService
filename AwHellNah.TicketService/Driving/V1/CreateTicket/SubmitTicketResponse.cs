using Frametux.Shared.Core.Driving.Common.Responses.Success;

namespace AwHellNah.TicketService.Driving.V1.CreateTicket;

public record SubmitTicketResponse : SuccessResponseWithData<SubmitTicketData>;

public record SubmitTicketData
{
    public required string Id { get; init; }
}