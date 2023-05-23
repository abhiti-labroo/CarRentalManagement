using CarRentalManagement.CarService.DataAcessLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace CarRentalManagement.CarService.DataAcessLayer.Data
{
    public class CarDbContext : DbContext
    {
        public CarDbContext(DbContextOptions<CarDbContext>options) : base(options) { }
        public virtual DbSet<Car>CarsFromInventory { get; set; } = null!;
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Car>().HasKey(c => c.CarId);
            modelBuilder.Entity<Car>().Property(c => c.CarType).IsRequired().HasMaxLength(64);
            modelBuilder.Entity<Car>().Property(c => c.CarBrand).IsRequired().HasMaxLength(64);
            modelBuilder.Entity<Car>().Property(c => c.CarModel).IsRequired().HasMaxLength(64);
            modelBuilder.Entity<Car>().Property(c => c.BuyDate).HasColumnType("datetime2");
            modelBuilder.Entity<Car>().Property(c => c.BuyCost).HasColumnType("decimal(18,2)");
            modelBuilder.Entity<Car>().Property(c => c.RentCostPerHour).HasColumnType("decimal(18,2)");
            modelBuilder.Entity<Car>().Property(c => c.RentCostPerDay).HasColumnType("decimal(18,2)");
            modelBuilder.Entity<Car>().Property(c => c.RentCostPerWeek).HasColumnType("decimal(18,2)");
            modelBuilder.Entity<Car>().Property(c => c.Inventory).IsRequired();
            base.OnModelCreating(modelBuilder);
        }
    }
}
