using AwHellNah.TicketService.Domain.TicketAggregate.Entities;
using AwHellNah.TicketService.Domain.TicketAggregate.ValueObjs;
using Frametux.Shared.Core.Domain.ValueObjs;
using Frametux.Shared.Core.Driven.Persistence.EntityConfigs.Conversions;
using Frametux.Shared.Driven.NpgsqlPersistence.EntityConfigs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AwHellNah.TicketService.Driven.Persistence.EntityConfigs;

public class TicketEntityTypeConfig : BaseEntityTypeConfig<Ticket>
{
    public override void Configure(EntityTypeBuilder<Ticket> builder)
    {
        base.Configure(builder);

        builder
            .HasIndex(e => e.CreatorUserId);
        
        builder
            .Property(e => e.Title)
            .IsRequired()
            .HasMaxLength(TicketTitle.MaxLength)
            .HasValueObjConversion<TicketTitle, string>();

        builder
            .Property(e => e.Description)
            .IsRequired(false)
            .HasColumnType("TEXT")
            .HasValueObjNullableConversion<TicketDescription, string>();
        
        builder
            .Property(e => e.CreatorUserId)
            .IsRequired()
            .HasMaxLength(Id.MaxLength)
            .HasValueObjConversion<Id, string>();
    }
}