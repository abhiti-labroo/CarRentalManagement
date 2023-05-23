using CarRentalManagement.UserManagementService.DataALayer.Models;

namespace CarRentalManagement.UserManagementService.DataALayer.Repositories
{
    public interface IUserMRepos
    {
        User GetUserByEmail(string email);
        void CreateUser(User user);
    }
}
