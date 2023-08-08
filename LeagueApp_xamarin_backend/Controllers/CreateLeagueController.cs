using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using LeagueApp_xamarin_backend.Data;
using LeagueApp_xamarin_backend.Models;
using Microsoft.Extensions.Logging;

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
        public async Task<IActionResult> CreateLeague([FromBody] League model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var response = new ApiResponse();


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
                    RegistrationEndDate = model.RegistrationEndDate
                };

                // Add the new league to the database
                _context.CreateLeague(newLeague);

                response.Message = "League Creation Successful.";
                // Return a success response
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