using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration;
    public class TransportConfiguration : IEntityTypeConfiguration<Transport>
    {
        public void Configure(EntityTypeBuilder<Transport> builder)
        {
            builder.HasKey(e => e.Id).HasName("PRIMARY");

            builder.ToTable("transport");

            builder.Property(e => e.Id).ValueGeneratedNever();
            builder.Property(e => e.FlightCarrier).HasMaxLength(45);
            builder.Property(e => e.FlightNumber).HasMaxLength(45);
        }
    }