using CarRentalManagement.UserManagementService.BusinessLLayer.UserDto;
using CarRentalManagement.UserManagementService.DataALayer.Models;
using CarRentalManagement.UserManagementService.DataALayer.Repositories;
using System.Security.Cryptography;
using System.Text;

namespace CarRentalManagement.UserManagementService.BusinessLLayer.Services
{
    public class UserService:IUserService
    {

        private readonly IUserMRepos _userRepository;
        public UserService(IUserMRepos userRepository)
        {
            _userRepository = userRepository;
        }
        public void Signup(UserSDto authUserDto)
        {
            // Check if the user with the given email already exists
            if (_userRepository.GetUserByEmail(authUserDto.Email) != null)
            {
                throw new Exception("Email already exists");
            }
            // Hash the password
            var hashedPassword = HashPassword(authUserDto.Password);



            // Add the new user to the database
            var userEntity = new User
            {
                Name = authUserDto.Name,
                Email = authUserDto.Email,
                Password = hashedPassword,
                // PasswordConfirmation = hashedPassword;
                PasswordConfirmation = authUserDto.PasswordConfirmation,
                Role = authUserDto.Role,
            };
            _userRepository.CreateUser(userEntity);
        }
        public UserSDto Login(LoginDto loginRequest)
        {
            // Retrieve the user with the given email from the database
            var userEntity = _userRepository.GetUserByEmail(loginRequest.Email);
            if (userEntity == null)
            {
                throw new Exception("Email does not exist");
            }



            // Check if the given password matches the user's password
            var hashedPassword = HashPassword(loginRequest.Password);
            if (userEntity.Password != hashedPassword)
            {
                throw new Exception("Invalid password");
            }



            // Return the user object
            return new UserSDto
            {
                AuthUserDtoId = userEntity.AuthUserId,
                Name = userEntity.Name,
                Email = userEntity.Email,
                Password = userEntity.Password,
                PasswordConfirmation = userEntity.PasswordConfirmation,
                Role = userEntity.Role



            };
        }
        public string HashPassword(string password)
        {
            using var sha256 = SHA256.Create();
            var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
            return BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
        }

    }
}

