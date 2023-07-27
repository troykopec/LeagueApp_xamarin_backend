using System.Linq;
using LeagueApp_xamarin_backend.Data;
using LeagueApp_xamarin_backend.Models;

namespace LeagueApp_xamarin_backend.DataAccess
{
    public class MyDataAccess
    {
        private readonly MyDbContext dbContext;

        public MyDataAccess(MyDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public List<Item> GetItems()
        {
            return dbContext.Items.ToList();
        }

        // Add other methods for inserting, updating, and deleting data as needed
    }
}