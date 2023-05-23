using CarRentalManagement.PaymentService.DataAcLayer.Models;
using Microsoft.EntityFrameworkCore;
namespace CarRentalManagement.PaymentService.DataAcLayer.Data{
    public class PaymentDbContext : DbContext{
        public DbSet<Payment> Payments { get; set; } = null!;
        public PaymentDbContext(DbContextOptions<PaymentDbContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder){
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Payment>().HasKey(p => p.PaymentId);
            modelBuilder.Entity<Payment>().Property(p => p.PaymentType).HasMaxLength(50).IsRequired();
            modelBuilder.Entity<Payment>().Property(p => p.PaymentStatus).HasMaxLength(50).IsRequired();
            modelBuilder.Entity<Payment>().HasOne(p => p.Rental).WithMany().HasForeignKey(p => p.RentalId).OnDelete(DeleteBehavior.Restrict);
}}}
