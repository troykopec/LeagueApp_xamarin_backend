using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using LeagueApp_xamarin_backend.Models;
using LeagueApp_xamarin_backend.Data;
using Microsoft.Extensions.Logging;

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
            if (user == null)
            {
                return BadRequest("User data is null.");
            }

            // Set the CreatedAt and UpdatedAt properties to the current datetime
            user.CreatedAt = DateTime.Now;
            user.UpdatedAt = DateTime.Now;

            // Call the SignupUser method in the ApplicationDbContext to save the user data
            _context.SignupUser(user);

            // Return a success response
            return Ok("Signup successful.");
        }
    }
}