using Microsoft.EntityFrameworkCore;
using OpsPortal.API.Models;
using Environment = OpsPortal.API.Models.Environment;

namespace OpsPortal.API.Data
{
    public class OpsPortalContext : DbContext
    {
        public OpsPortalContext(DbContextOptions<OpsPortalContext> options) : base(options) { }

        public DbSet<Service> Services { get; set; }
        public DbSet<Environment> Environments { get; set; }
        public DbSet<Deployment> Deployments { get; set; }
        public DbSet<Incident> Incidents { get; set; }
        public DbSet<Vulnerability> Vulnerabilities { get; set; }
        public DbSet<Documentation> Documentation { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Seed specific data for Environments
            modelBuilder.Entity<Models.Environment>().HasData(
                new Models.Environment { Id = 1, Name = "Development", IsProduction = false },
                new Models.Environment { Id = 2, Name = "Staging", IsProduction = false },
                new Models.Environment { Id = 3, Name = "Production", IsProduction = true }
            );

            // Configure relationships if needed explicitly (EF Core usually infers these well)
            modelBuilder.Entity<Deployment>()
                .HasOne(d => d.Service)
                .WithMany(s => s.Deployments)
                .HasForeignKey(d => d.ServiceId);
        }
    }
}