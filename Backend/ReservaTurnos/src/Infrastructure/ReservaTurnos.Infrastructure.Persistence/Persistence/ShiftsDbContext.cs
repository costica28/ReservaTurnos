using Microsoft.EntityFrameworkCore;
using ReservaTurnos.Core.Domain.Models;

namespace ReservaTurnos.Infrastructure.Persistence.Persistence
{
    public class ShiftsDbContext: DbContext
    {

        public ShiftsDbContext(DbContextOptions<ShiftsDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Commerce>()
            //    .HasMany(m => m.Services)
            //    .WithOne(m => m.Commerce)
            //    .HasForeignKey(m => m.id_comercio)
            //    .IsRequired()
            //    .OnDelete(DeleteBehavior.Restrict);

            //modelBuilder.Entity<Shift>()
            //    .HasMany(m => m.Services)
            //    .WithOne(m => m.Shift)
            //    .HasForeignKey(m => m.id_servicio)
            //    .IsRequired()
            //    .OnDelete(DeleteBehavior.Restrict);
        }

        public DbSet<Commerce> Commerces { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Shift> Shifts { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Rol> Rols { get; set; }

    }
}
