using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LeagueApp_xamarin_backend.Data;
using System.Linq;
using System.Security.Claims;
using LeagueApp_xamarin_backend.Models;
using Newtonsoft.Json;

[ApiController]
[Route("api/[controller]")]
public class MyLeaguesController : Controller
{
    private readonly MyDbContext _dbContext;

    public MyLeaguesController(MyDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    [HttpGet]
    [Authorize]
    public IActionResult GetLeague()
    {
        var response = new ApiResponse();
        // Get the user's ID
        var userIdString = User.FindFirstValue("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier");        

        if (!string.IsNullOrEmpty(userIdString) && int.TryParse(userIdString, out int userId))
        {
            // Retrieve leagues where the user is the organizer
            var myLeagues = _dbContext.GetLeagues;

            var leagues_string = JsonConvert.SerializeObject(myLeagues);

            response.Message = leagues_string;
        }
        else
        {
            // Handle the case where userIdString is null or not a valid integer
            response.Message = $"Error: Invalid user ID. id: {userIdString}";
        }
        return Ok(response);
    }
}