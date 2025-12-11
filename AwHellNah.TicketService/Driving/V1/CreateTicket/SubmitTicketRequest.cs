using AwHellNah.TicketService.Domain.TicketAggregate.ValueObjs;
using FluentValidation;

namespace AwHellNah.TicketService.Driving.V1.CreateTicket;

public record SubmitTicketRequest(string Title, string? Description = null);

public class SubmitTicketRequestValidator : AbstractValidator<SubmitTicketRequest>
{
    public SubmitTicketRequestValidator()
    {
        RuleFor(c => c.Title)
            .SetValidator(TicketTitle.Validator);
        
        RuleFor(c => c.Description)
            .SetValidator(TicketDescription.Validator!)
            .When(c => c.Description is not null);
    }
}