using CarRentalManagement.UserManagementService.BusinessLLayer.UserDto;

namespace CarRentalManagement.UserManagementService.BusinessLLayer.Services
{
    public interface IUserService
    {
        void Signup(UserSDto authUserDto);
        UserSDto Login(LoginDto loginRequest);
        string HashPassword(string password);

    }
}
