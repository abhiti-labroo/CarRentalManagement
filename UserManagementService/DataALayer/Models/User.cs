using System.ComponentModel.DataAnnotations;
using System.Data;

namespace CarRentalManagement.UserManagementService.DataALayer.Models
{
    public class User
    {
        [Key]
        public int AuthUserId { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string Name { get; set; } = null!;

        [Required]
        public string Email { get; set; } = null!;

        [Required]
        [StringLength(150, MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;

        [Required]
        [StringLength(150, MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Compare(nameof(Password), ErrorMessage = "The password and confirmation password do not match.")]
        public string PasswordConfirmation { get; set; } = null!;
        public AuthRoleType Role { get; set; }

    }
    public enum AuthRoleType
    {
        Admin,
        User
    }


}
