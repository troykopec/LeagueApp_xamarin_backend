using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using LeagueApp_xamarin_backend.Models; // Import the Item model from the Models folder
using LeagueApp_xamarin_backend.DataAccess;

namespace LeagueApp_xamarin_backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SampleController : ControllerBase
    {
        private readonly MyDataAccess dataAccess; // Use List<Item> instead of List<string>

        public SampleController(MyDataAccess dataAccess)
        {
            this.dataAccess = dataAccess;
        }

        // GET: api/sample
        [HttpGet]
        public ActionResult<IEnumerable<Item>> GetItems()
        {
            var items = dataAccess.GetItems(); // Call the GetItems method from your DataAccessClass

            if (items != null)
            {
                return Ok(items);
            }

            return NotFound();
        }
    }
}