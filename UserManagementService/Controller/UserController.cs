using CarRentalManagement.UserManagementService.BusinessLLayer.Services;
using CarRentalManagement.UserManagementService.BusinessLLayer.UserDto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CarRentalManagement.UserManagementService.Controller
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IConfiguration _configuration;
        public UserController(IUserService authUserService, IConfiguration configuration)
        {
            _userService = authUserService;
            _configuration = configuration;
        }
        [HttpPost("signup")]
        public IActionResult Signup(UserSDto authUserDto)
        {
            try
            {
                _userService.Signup(authUserDto);
                return Ok(authUserDto);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginDto loginRequest)
        {
            try
            {
                var user = _userService.Login(loginRequest);

                // Generate JWT Token
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_configuration.GetValue<string>("Jwt:Key"));
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[] {
                              new Claim(ClaimTypes.Name, user.Name),
                              new Claim(ClaimTypes.Email, user.Email),
                              new Claim(ClaimTypes.Role,user.Role.ToString())
 }),
                    Expires = DateTime.UtcNow.AddHours(_configuration.GetValue<int>("Jwt:ExpiryInHours")),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                var tokenString = tokenHandler.WriteToken(token);



                // Return JWT token
                return Ok(new { Token = tokenString });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }

}
