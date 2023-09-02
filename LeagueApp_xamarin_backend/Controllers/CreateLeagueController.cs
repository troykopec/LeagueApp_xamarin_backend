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
    public class CreateLeagueController : ControllerBase
    {
        private readonly MyDbContext _context;
        private readonly ILogger<CreateLeagueController> _logger;

        public CreateLeagueController(MyDbContext context, ILogger<CreateLeagueController> logger)
        {
            _context = context;
            _logger = logger;
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreateLeague([FromBody] League model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var response = new ApiResponse();

                var userIdString = User.FindFirstValue("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier");        
                var username = User.FindFirstValue(JwtRegisteredClaimNames.UniqueName);

                if (!string.IsNullOrEmpty(userIdString) && int.TryParse(userIdString, out int userId))
                {
                    // Create a new League object based on the input model
                    var newLeague = new League
                    {
                        LeagueName = model.LeagueName,
                        Description = model.Description,
                        SportType = model.SportType,
                        RegistrationFee = model.RegistrationFee,
                        MaxTeamCapacity = model.MaxTeamCapacity,
                        MaxTeams = model.MaxTeams,
                        StartDate = model.StartDate,
                        EndDate = model.EndDate,
                        RegistrationStartDate = model.RegistrationStartDate,
                        RegistrationEndDate = model.RegistrationEndDate,
                        OrganizerId = userId,
                        Teams = model.Teams
                    };

                    // Add the new league to the database
                    _context.CreateLeague(newLeague);

                    // ...
                    response.Message = $"League Creation Successful. League Details: {JsonConvert.SerializeObject(newLeague)}";
                }
                else
                {
                    // Handle the case where userIdString is null or not a valid integer
                    response.Message = $"Error: Invalid user ID. id: {userIdString}";
                }  // Return a success response
                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while creating a league.");
                return StatusCode(500, "An error occurred while creating a league.");
            }
        }
    }
}