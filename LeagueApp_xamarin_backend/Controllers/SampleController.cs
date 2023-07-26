using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using LeagueApp_xamarin_backend.Models; // Import the Item model from the Models folder

namespace LeagueApp_xamarin_backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SampleController : ControllerBase
    {
        private readonly List<Item> _data; // Use List<Item> instead of List<string>

        public SampleController()
        {
            // Sample data for demonstration purposes
            _data = new List<Item>
            {
                new Item { Id = "1", Text = "Item 1", Description = "Description for Item 1" },
                new Item { Id = "2", Text = "Item 2", Description = "Description for Item 2" },
                new Item { Id = "3", Text = "Item 3", Description = "Description for Item 3" }
            };
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_data); // Return the list of Item objects
        }

        [HttpPost]
        public IActionResult Post([FromBody] string item)
        {
            _data.Add(new Item { Id = _data.Count.ToString(), Text = item, Description = "Description for " + item }); // Add a new Item object
            return Ok();
        }
    }
}