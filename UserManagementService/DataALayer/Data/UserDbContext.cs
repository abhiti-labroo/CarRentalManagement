using CarRentalManagement.UserManagementService.DataALayer.Models;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace CarRentalManagement.UserManagementService.DataALayer.Data
{
    public class UserDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public UserDbContext(DbContextOptions<UserDbContext> options) : base(options){}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);
        }

    }
}

