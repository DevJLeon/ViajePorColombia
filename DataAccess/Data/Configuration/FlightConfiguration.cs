using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration;
    public class FlightConfiguration : IEntityTypeConfiguration<Flight>
    {
        public void Configure(EntityTypeBuilder<Flight> builder)
        {
            builder.HasKey(e => e.Id).HasName("PRIMARY");

            builder.ToTable("flight");

            builder.HasIndex(e => e.TransportId, "fk_Flight_Transport_idx");

            builder.Property(e => e.Id).ValueGeneratedNever();
            builder.Property(e => e.Destination).HasMaxLength(45);
            builder.Property(e => e.Origin).HasMaxLength(45);

            builder.HasOne(d => d.Transport).WithMany(p => p.Flights)
                .HasForeignKey(d => d.TransportId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Flight_Transport");
        }
    }