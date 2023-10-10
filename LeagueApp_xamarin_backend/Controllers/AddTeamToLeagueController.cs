using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using LeagueApp_xamarin_backend.Data;
using LeagueApp_xamarin_backend.Models;
using Microsoft.Extensions.Logging;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using System.IdentityModel.Tokens.Jwt;
using Newtonsoft.Json;

namespace LeagueApp_xamarin_backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AddTeamToLeagueController : ControllerBase
    {
        private readonly MyDbContext _context;
        private readonly ILogger<AddTeamToLeagueController> _logger;

        public AddTeamToLeagueController(MyDbContext context, ILogger<AddTeamToLeagueController> logger)
        {
            _context = context;
            _logger = logger;
        }

        [HttpPost]
        [Authorize]
        public IActionResult AddTeam([FromBody] Team model)
        {
            try
            {
                var response = new ApiResponse();

                // Your original code to get user information
                var userIdString = User.FindFirstValue("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier");
                var username = User.FindFirstValue(JwtRegisteredClaimNames.UniqueName);

                // Simplified response message
                response.Message = $"team addition Successful. team Details: {JsonConvert.SerializeObject(model.TeamName)}";

                // Return a success response
                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while creating a team.");
                return StatusCode(500, $"An error occurred while creating a team. Details: {ex.Message}");
            }
        }
    }
}