using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration;
public class JourneyConfiguration : IEntityTypeConfiguration<Journey>
{
    public void Configure(EntityTypeBuilder<Journey> builder)
    {
        builder.Property(e => e.Origin)
        .HasMaxLength(30)
        .IsRequired();

        builder.Property(e => e.Price)
        .HasPrecision(15, 2)
        .IsRequired();

        builder.Property(e => e.Destination)
        .HasMaxLength(30)
        .IsRequired();

        builder.HasMany(e => e.Flights)
        .WithMany(e => e.Journies)
        .UsingEntity<JourneyFlight>(

            jp => jp.HasOne(e => e.Flight)
            .WithMany(e => e.JourneyFlights)
            .HasForeignKey(e => e.IdFlightFK)
            .OnDelete(DeleteBehavior.Cascade),

            jp => jp.HasOne(e => e.Journey)
            .WithMany(e => e.JourneyFlights)
            .HasForeignKey(e => e.IdJourneyFK)
            .OnDelete(DeleteBehavior.Cascade),
            entity =>
            {
                entity.HasKey(e => new { e.IdJourneyFK, e.IdFlightFK });
            }
        );
    }
}