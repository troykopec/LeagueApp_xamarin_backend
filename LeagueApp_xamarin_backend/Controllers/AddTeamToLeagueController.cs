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
//
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
        public async Task<IActionResult> AddTeam([FromBody] Team model)
        {
            try
            {   
                if (!ModelState.IsValid)
                {
                    var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage);
                    return BadRequest(new { Message = "Invalid model state", Errors = errors });
                }
                
                var response = new ApiResponse();

                var userIdString = User.FindFirstValue("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier");        
                var username = User.FindFirstValue(JwtRegisteredClaimNames.UniqueName);
                
                if (!string.IsNullOrEmpty(userIdString) && int.TryParse(userIdString, out int userId))
                {   
                    // Create a new League object based on the input model
                    string uniqueCode = model.UniqueCode;
                    var league = _context.Leagues.FirstOrDefault(l => l.UniqueCode == uniqueCode);
                    if (league == null)
                    {
                        return NotFound($"No league found with the unique code: {uniqueCode}");
                    }

                    var newTeam = new Team
                    {
                        TeamName = model.TeamName,
                        LeagueId = league.Id,
                        Players = model.Players,
                        TeamLeaderId = userId,
                    };
                    

                    // Add the new team to the database
                    _context.AddTeamToLeague(newTeam);

                    // ...
                    
                    response.Message = $"team addition Successful. team Details: {JsonConvert.SerializeObject(userIdString)}";
                }
                else
                {
                    // Handle the case where userIdString is null or not a valid integer
                    response.Message = $"Error: Invalid user ID. id: {userIdString}";
                }  
                
                // Return a success response
                response.Message = $"team addition Successful. team Details: {JsonConvert.SerializeObject(userIdString)}";
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