using EntityFrameworkCore.CreatedUpdatedDate.Extensions;
using Microsoft.EntityFrameworkCore;
using si730pc2u20211c211.API.Hr.Domain.Model.Aggregates;
using si730pc2u20211c211.API.shared.Infrastructure.Persistence.EFC.Configuration.Extensions;

namespace si730pc2u20211c211.API.Shared.Infrastructure.Persistence.EFC.Configuration;


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
         
        builder.Entity<JoinRequest>().HasKey(p => p.Id);
        builder.Entity<JoinRequest>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<JoinRequest>().Property(p => p.Name).IsRequired().HasMaxLength(30);
        builder.Entity<JoinRequest>().Property(p => p.DepartmentId).IsRequired();
        builder.Entity<JoinRequest>().Property(p => p.DesiredJobTitle).IsRequired();
        builder.Entity<JoinRequest>().Property(p => p.ResumeUrl).IsRequired();
         
        // Apply SnakeCase Naming Convention
        builder.UseSnakeCaseWithPluralizedTableNamingConvention();
    }
}