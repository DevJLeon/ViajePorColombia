using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration;
    public class JourneyflightConfiguration : IEntityTypeConfiguration<Journeyflight>
    {
        public void Configure(EntityTypeBuilder<Journeyflight> builder)
        {
            builder.HasKey(e => e.FlightId).HasName("PRIMARY");

            builder.ToTable("journeyflight");

            builder.HasIndex(e => e.FlightId, "fk_JourneyFlight_Flight1_idx");

            builder.HasIndex(e => e.JourneyId, "fk_JourneyFlight_Journey1_idx");

            builder.Property(e => e.FlightId)
                .ValueGeneratedNever()
                .HasColumnName("Flight_Id");
            builder.Property(e => e.JourneyId).HasColumnName("Journey_Id");

            builder.HasOne(d => d.Flight).WithOne(p => p.Journeyflight)
                .HasForeignKey<Journeyflight>(d => d.FlightId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_JourneyFlight_Flight1");

            builder.HasOne(d => d.Journey).WithMany(p => p.Journeyflights)
                .HasForeignKey(d => d.JourneyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_JourneyFlight_Journey1");
        }
    }