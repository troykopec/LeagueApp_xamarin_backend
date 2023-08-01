using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using LeagueApp_xamarin_backend.Models;
using LeagueApp_xamarin_backend.Data;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json; // Add this using statement

namespace LeagueApp_xamarin_backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SignupController : ControllerBase
    {
        private readonly MyDbContext _context;
        private readonly ILogger<SignupController> _logger;

        public SignupController(MyDbContext context, ILogger<SignupController> logger)
        {
            _context = context;
            _logger = logger;
        }

        // HTTP POST endpoint for signup
        [HttpPost]
        public IActionResult Signup([FromBody] User user)
        {
            var response = new ApiResponse();
            var messages = new List<string>();

            // Check if the email is already taken
            if (_context.IsEmailTaken(user.Email))
            {
                messages.Add("Email taken");
            }

            // Check if the username is already taken
            if (_context.IsUsernameTaken(user.Username))
            {
                messages.Add("Username taken");
            }

            if (messages.Count > 0)
            {
                response.Message = string.Join(", ", messages);
                return Ok(response);
            }

            
            user.CreatedAt = DateTime.Now;
            user.UpdatedAt = DateTime.Now;
            
            // Call the SignupUser method in the ApplicationDbContext to save the user data
            _context.SignupUser(user);
            
            // Return a JSON object with a "message" property
            
            response.Message = "Signup successful.";
            // Return a success response
            return Ok(response);

            
        }
    }
}