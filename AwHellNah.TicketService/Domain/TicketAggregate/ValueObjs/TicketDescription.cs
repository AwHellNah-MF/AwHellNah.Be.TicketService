using FluentValidation;
using Frametux.Shared.Core.Domain.ValueObjs.Base;

namespace AwHellNah.TicketService.Domain.TicketAggregate.ValueObjs;

public record TicketDescription : ISinglePropValueObj<string>
{
    public const int MaxLength = 9999999;

    public string Value { get; }

    public static InlineValidator<string> Validator { get; } = new()
    {
        v => v.RuleFor(x => x)
            .NotNull()
            .MaximumLength(MaxLength)
    };

    public TicketDescription(string value)
    {
        Validator.ValidateAndThrow(value);
        Value = value;
    }

    public static implicit operator string(TicketDescription obj) => obj.Value;
    public static implicit operator TicketDescription(string value) => new(value);
}