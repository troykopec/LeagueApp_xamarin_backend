using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace LeagueApp_xamarin_backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SampleController : ControllerBase
    {
        private readonly List<string> _data;

        public SampleController()
        {
            // Sample data for demonstration purposes
            _data = new List<string> { "Item 1", "Item 2", "Item 3" };
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_data);
        }

        [HttpPost]
        public IActionResult Post([FromBody] string item)
        {
            _data.Add(item);
            return Ok();
        }
    }
}