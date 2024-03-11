using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration;
    public class FlightConfiguration : IEntityTypeConfiguration<Flight>
    {
    public void Configure(EntityTypeBuilder<Flight> builder)
    {
        builder.Property(e => e.Destination)
        .HasMaxLength(40)
        .IsRequired();

        builder.Property(e => e.Price)
        .HasPrecision(15,2)
        .IsRequired();

        builder.Property(e => e.Origin)
        .HasMaxLength(40)
        .IsRequired();

        builder.HasOne(e => e.Transport)
        .WithMany(e => e.Flights)
        .HasForeignKey(e => e.IdTransportFK);
    }
}