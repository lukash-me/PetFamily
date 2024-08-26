using System.Data.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using PetFamily.Domain.Species.AggregateRoot;
using PetFamily.Domain.Volunteers;
using PetFamily.Domain.Volunteers.AggregateRoot;
using PetFamily.Domain.Volunteers.Entities;

namespace PetFamily.DataAccess;

public class ApplicationDbContext(IConfiguration configuration) : DbContext
{
    public DbSet<Volunteer> Volunteer { get; set; }
    public DbSet<Pet> Pet { get; set; }
    public DbSet<Species> Species { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder
            .UseNpgsql(configuration.GetConnectionString(nameof(DbConnection)))
            .UseSnakeCaseNamingConvention()
            .UseLoggerFactory(CreateLoggerFactory())
            .EnableSensitiveDataLogging();
    }

    public ILoggerFactory CreateLoggerFactory() =>
        LoggerFactory.Create(builder => { builder.AddConsole(); });

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
    
        base.OnModelCreating(modelBuilder);
    }
}