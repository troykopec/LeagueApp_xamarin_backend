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
        var userId = User.FindFirstValue("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier");        
        var username = User.FindFirstValue(JwtRegisteredClaimNames.Name);
        var claims = User.Claims.Select(c => new { c.Type, c.Value });

        // Additional logic to fetch user data, etc.
        return Ok(new
        {
            Message = $"Successfully Authenticated on Backend. id: {userId}",
            Claims = claims
        });    }
}