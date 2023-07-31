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
            
            // Call the SignupUser method in the ApplicationDbContext to save the user data
            _context.SignupUser(user);

            // Return a success response
            return Ok("Signup successful.");
        }
    }
}