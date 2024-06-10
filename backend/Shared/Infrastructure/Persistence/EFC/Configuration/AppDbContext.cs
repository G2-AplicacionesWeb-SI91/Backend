using backend.Shared.Infrastructure.Persistence.EFC.Configuration.Extensions;
using backend.tracking;
using EntityFrameworkCore.CreatedUpdatedDate.Extensions;
using Microsoft.EntityFrameworkCore;

namespace backend.Shared.Infrastructure.Persistence.EFC.Configuration;

public class AppDbContext(DbContextOptions options) : DbContext(options)
{
    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
        base.OnConfiguring(builder);
        // Enable Audit Fields Interceptors
        builder.AddCreatedUpdatedInterceptor();
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        
        
        
        // BusRoute Context
        builder.Entity<BusRoute>().HasKey(b => b.Id);
        builder.Entity<BusRoute>().Property(b => b.Id).IsRequired().ValueGeneratedOnAdd();
        
        // builder.Entity<BusRoute>().OwnsOne(b => b., n =>
        // {
        //     n.WithOwner().HasForeignKey("Id");
        //     n.Property(b => b.).HasColumnName("Distance");
        // })
        
        // Apply SnakeCase Naming Convention
        builder.UseSnakeCaseWithPluralizedTableNamingConvention();
    }
}