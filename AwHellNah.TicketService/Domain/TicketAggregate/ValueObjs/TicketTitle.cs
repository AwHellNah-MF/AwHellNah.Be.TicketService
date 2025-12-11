using FluentValidation;
using Frametux.Shared.Core.Domain.ValueObjs.Base;

namespace AwHellNah.TicketService.Domain.TicketAggregate.ValueObjs;

public record TicketTitle : ISinglePropValueObj<string>
{
    public const int MaxLength = 200;

    public string Value { get; }

    public static InlineValidator<string> Validator { get; } = new()
    {
        v => v.RuleFor(x => x)
            .NotEmpty()
            .MaximumLength(MaxLength)
    };

    public TicketTitle(string value)
    {
        Validator.ValidateAndThrow(value);
        Value = value;
    }

    public static implicit operator string(TicketTitle obj) => obj.Value;
    public static implicit operator TicketTitle(string value) => new(value);
}