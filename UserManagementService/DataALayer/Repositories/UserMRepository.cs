using CarRentalManagement.UserManagementService.DataALayer.Data;
using CarRentalManagement.UserManagementService.DataALayer.Models;
using Microsoft.EntityFrameworkCore;

namespace CarRentalManagement.UserManagementService.DataALayer.Repositories
{
    public class UserMRepository:IUserMRepos
    {
        private readonly UserDbContext _context;

        public UserMRepository(UserDbContext applicationDbContext)
        {
            _context = applicationDbContext;
        }
        public User GetUserByEmail(string email)
        {
            return _context.Users.SingleOrDefault(u => u.Email == email);
        }
        public void CreateUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

    }
}
