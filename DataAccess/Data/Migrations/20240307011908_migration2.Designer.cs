﻿// <auto-generated />
using DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DataAccess.Data.Migrations
{
    [DbContext(typeof(ApiContext))]
    [Migration("20240307011908_migration2")]
    partial class migration2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.16")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            modelBuilder.Entity("Business.Entity.Flight", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    b.Property<string>("Destination")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("varchar(40)")
                        .HasColumnName("Destination");

                    b.Property<int>("IdTransportFK")
                        .HasColumnType("int")
                        .HasColumnName("IdTransportFK");

                    b.Property<string>("Origin")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("varchar(40)")
                        .HasColumnName("Origin");

                    b.Property<double>("Price")
                        .HasPrecision(15, 2)
                        .HasColumnType("double(15,2)")
                        .HasColumnName("Price");

                    b.HasKey("Id");

                    b.HasIndex("IdTransportFK");

                    b.ToTable("Flights");
                });

            modelBuilder.Entity("Business.Entity.Journey", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    b.Property<string>("Destination")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("varchar(30)")
                        .HasColumnName("Destination");

                    b.Property<string>("Origin")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("varchar(30)")
                        .HasColumnName("Origin");

                    b.Property<double>("Price")
                        .HasPrecision(15, 2)
                        .HasColumnType("double(15,2)")
                        .HasColumnName("Price");

                    b.HasKey("Id");

                    b.ToTable("Journies");
                });

            modelBuilder.Entity("Business.Entity.JourneyFlight", b =>
                {
                    b.Property<int>("IdJourneyFK")
                        .HasColumnType("int")
                        .HasColumnName("IdJourneyFK");

                    b.Property<int>("IdFlightFK")
                        .HasColumnType("int")
                        .HasColumnName("IdFlightFK");

                    b.HasKey("IdJourneyFK", "IdFlightFK");

                    b.HasIndex("IdFlightFK");

                    b.ToTable("JourneyFlight");
                });

            modelBuilder.Entity("Business.Entity.Transport", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    b.Property<string>("FlightCarrier")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("varchar(30)")
                        .HasColumnName("FlightCarrier");

                    b.Property<string>("FlightNumber")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("varchar(30)")
                        .HasColumnName("FlightNumber");

                    b.HasKey("Id");

                    b.ToTable("Transports");
                });

            modelBuilder.Entity("Business.Entity.Flight", b =>
                {
                    b.HasOne("Business.Entity.Transport", "Transport")
                        .WithMany("Flights")
                        .HasForeignKey("IdTransportFK")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Transport");
                });

            modelBuilder.Entity("Business.Entity.JourneyFlight", b =>
                {
                    b.HasOne("Business.Entity.Flight", "Flight")
                        .WithMany("JourneyFlights")
                        .HasForeignKey("IdFlightFK")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Business.Entity.Journey", "Journey")
                        .WithMany("JourneyFlights")
                        .HasForeignKey("IdJourneyFK")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Flight");

                    b.Navigation("Journey");
                });

            modelBuilder.Entity("Business.Entity.Flight", b =>
                {
                    b.Navigation("JourneyFlights");
                });

            modelBuilder.Entity("Business.Entity.Journey", b =>
                {
                    b.Navigation("JourneyFlights");
                });

            modelBuilder.Entity("Business.Entity.Transport", b =>
                {
                    b.Navigation("Flights");
                });
#pragma warning restore 612, 618
        }
    }
}