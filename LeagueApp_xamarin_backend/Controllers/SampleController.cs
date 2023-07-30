using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using LeagueApp_xamarin_backend.Models; // Import the Item model from the Models folder
using LeagueApp_xamarin_backend.DataAccess;
using Microsoft.Extensions.Logging;

namespace LeagueApp_xamarin_backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SampleController : ControllerBase
    {
        private readonly List<Item> _data; // Use List<Item> instead of List<string>
        
        private readonly MyDataAccess _DataAccess;
        private readonly ILogger<SampleController> _logger;

        public SampleController(MyDataAccess DataAccess, ILogger<SampleController> logger)
        {
            _DataAccess = DataAccess;
            _logger = logger;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Item>> GetItems()
        {
            var items = _DataAccess.GetItems(); // Call the GetItems method from your MyDbContext
            _logger.LogInformation("Calling GetItems()");
            
            if (items != null)
            {
                return Ok(items);
            }

            return NotFound();
        }

        [HttpPost]
        public IActionResult Post([FromBody] string item)
        {
            _data.Add(new Item { Id = _data.Count, Text = item, Description = "Description for " + item }); // Add a new Item object
            return Ok();
        }
    }
}