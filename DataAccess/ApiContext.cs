using System.Reflection;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess;
public class ApiContext : DbContext
{
    public ApiContext(DbContextOptions options) : base(options)
    { }
    
    public virtual DbSet<Flight> Flights { get; set; }
    public virtual DbSet<Journey> Journeys { get; set; }
    public virtual DbSet<Journeyflight> Journeyflights { get; set; }
    public virtual DbSet<Transport> Transports { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }

/*
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");


        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
*/    

}
