using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using System.IdentityModel.Tokens.Jwt;

[ApiController]
[Route("api/[controller]")]
public class AuthenticateUser : ControllerBase
{
    // Example endpoint that requires authentication
    [HttpGet]
    [Authorize] // This attribute requires authentication for the endpoint
    public IActionResult GetAuthenticatedUserData()
    {
        // Access the user's claims
        var userId = User.FindFirstValue(JwtRegisteredClaimNames.Sub);
        var username = User.FindFirstValue(JwtRegisteredClaimNames.UniqueName);
        
        // Additional logic to fetch user data, etc.

        return Ok("Authenticated user data");
    }
}