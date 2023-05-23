using System.ComponentModel.DataAnnotations;

namespace CarRentalManagement.UserManagementService.BusinessLLayer.UserDto
{
    public class LoginDto
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; } = null!;
        [Required]
        public string Password { get; set; } = null!;

    }
}
