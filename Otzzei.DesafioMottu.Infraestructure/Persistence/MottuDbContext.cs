using Microsoft.EntityFrameworkCore;
using OtzzeiDesafioMottu.Domain.Entities;

namespace Otzzei.DesafioMottu.Infraestructure.Persistence
{
    public class MottuDbContext : DbContext
    {
        public MottuDbContext(DbContextOptions<MottuDbContext> options) : base(options) { }

        public DbSet<Motorcycle> Motorcycles { get; set; }
        public DbSet<MotorcycleNotification> Notifications { get; set; }
        public DbSet<DeliveryMan> DeliveryMen { get; set; }
        public DbSet<Rental> Rentals { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Rental>(entity =>
            {
                entity.OwnsOne(r => r.Plan, plan =>
                {
                    plan.Property(p => p.Days)
                        .HasColumnName("PlanDays");

                    plan.Property(p => p.DailyRate)
                        .HasColumnName("PlanDailyRate")
                        .HasColumnType("decimal(10,2)");

                    plan.Property(p => p.EarlyReturnPenalty)
                        .HasColumnName("PlanEarlyReturnPenalty")
                        .HasColumnType("decimal(10,2)");
                });
            });
        }
    }
}
