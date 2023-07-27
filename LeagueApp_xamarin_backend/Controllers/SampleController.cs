using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using LeagueApp_xamarin_backend.Models; // Import the Item model from the Models folder
using LeagueApp_xamarin_backend.Data;

namespace LeagueApp_xamarin_backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SampleController : ControllerBase
    {
        private readonly List<Item> _data; // Use List<Item> instead of List<string>
        
        private readonly MyDbContext _dbContext;

        public SampleController(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Item>> GetItems()
        {
            var items = _dbContext.GetItems(); // Call the GetItems method from your MyDbContext

            if (items != null)
            {
                return Ok(items);
            }

            return NotFound();
        }

        [HttpPost]
        public IActionResult Post([FromBody] string item)
        {
            _data.Add(new Item { Id = _data.Count.ToString(), Text = item, Description = "Description for " + item }); // Add a new Item object
            return Ok();
        }
    }
}