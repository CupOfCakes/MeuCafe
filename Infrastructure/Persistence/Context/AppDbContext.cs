using System.Reflection;
using Domain.Entities;
using Infrastructure.Persistence.Constraints;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Context;

public class AppDbContext : DbContext
{
    public DbSet<Client> Clients => Set<Client>();

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Client>(entity =>
        {
            entity.HasIndex(c => c.Name)
                .IsUnique()
                .HasDatabaseName(ClientConstraints.UniqueName);

            entity.HasIndex(c => c.Email)
                .IsUnique()
                .HasDatabaseName(ClientConstraints.UniqueEmail);
        });

        modelBuilder.ApplyConfigurationsFromAssembly(
            typeof(AppDbContext).Assembly
        );

        base.OnModelCreating(modelBuilder);
    }

}