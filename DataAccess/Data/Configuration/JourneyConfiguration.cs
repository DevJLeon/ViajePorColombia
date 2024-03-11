using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration;
    public class JourneyConfiguration : IEntityTypeConfiguration<Journey>
    {
        public void Configure(EntityTypeBuilder<Journey> builder)
        {
            builder.HasKey(e => e.Id).HasName("PRIMARY");

            builder.ToTable("journey");

            builder.Property(e => e.Id).ValueGeneratedNever();
            builder.Property(e => e.Destination).HasMaxLength(45);
            builder.Property(e => e.Origin).HasMaxLength(45);
        }
    }