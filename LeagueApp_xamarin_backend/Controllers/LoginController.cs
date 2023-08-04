using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using LeagueApp_xamarin_backend.Data;
using LeagueApp_xamarin_backend.Models;
using Microsoft.EntityFrameworkCore;
using BCrypt.Net;


namespace LeagueApp_xamarin_backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly MyDbContext _context;
        private readonly IConfiguration _configuration;

        public LoginController(MyDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            // Find the user by username or email
            var user = await _context.Users.SingleOrDefaultAsync(u =>
                (u.Username == model.UsernameOrEmail || u.Email == model.UsernameOrEmail));

            // If user not found or invalid credentials, return unauthorized status
            if (user == null || !BCrypt.Net.BCrypt.Verify(model.Password, user.Password))
            {
                return Unauthorized();
            }
            // Generate a JWT token for the authenticated user
            var token = GenerateJwtToken(user);

            // Return the token as a JSON response
            return Ok(new { Token = token });
        }

        private string GenerateJwtToken(User user)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:SecretKey"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserID.ToString()),
                new Claim(JwtRegisteredClaimNames.UniqueName, user.Username),
                // Add additional claims as needed (e.g., user roles)
            };

            var token = new JwtSecurityToken(
                _configuration["Jwt:Issuer"],
                _configuration["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddMinutes(int.Parse(_configuration["Jwt:ExpirationInMinutes"])),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}