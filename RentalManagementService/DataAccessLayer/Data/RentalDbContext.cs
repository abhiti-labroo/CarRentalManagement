using CarRentalManagement.RentalManagementService.DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
namespace CarRentalManagement.RentalManagementService.DataAccessLayer.Data
{
    public class RentalDbContext : DbContext
    {
         public RentalDbContext(DbContextOptions<RentalDbContext> options) : base(options) { }
        public virtual DbSet<Rental> Rentals { get; set; } = null!;
        public virtual DbSet<RentalCar> RentalCars { get; set; } = null!;
        public virtual DbSet<Customer> Customers { get; set; } = null!;
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Rental>().HasKey(r => r.RentalId);
            modelBuilder.Entity<Rental>().Property(r => r.RentalCarType).IsRequired().HasMaxLength(50);
            modelBuilder.Entity<Rental>().Property(r => r.RentalStartdate).IsRequired();
            modelBuilder.Entity<Rental>().Property(r => r.RentalEnddate).IsRequired();
            modelBuilder.Entity<Rental>().Property(r => r.RentalDuration).IsRequired();
            modelBuilder.Entity<Rental>().Property(r => r.TotalRentalAmount).IsRequired();
            modelBuilder.Entity<Rental>().Property(r => r.PaymentStatus).IsRequired().HasMaxLength(50);
            modelBuilder.Entity<Rental>().HasOne(r => r.Customer).WithMany(c => c.Rentals).HasForeignKey(r=> r.CusId).OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<RentalCar>().HasKey(rc => rc.RentalCarId);
            modelBuilder.Entity<RentalCar>().HasOne(rc => rc.Rental).WithMany(r=>r.RentalCars).HasForeignKey(rc => rc.RentalId).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Customer>().HasKey(c => c.CusId);
            modelBuilder.Entity<Customer>().HasMany(c => c.Rentals).WithOne(r => r.Customer).HasForeignKey(r => r.CusId).OnDelete(DeleteBehavior.Cascade);
        }


    }
}
