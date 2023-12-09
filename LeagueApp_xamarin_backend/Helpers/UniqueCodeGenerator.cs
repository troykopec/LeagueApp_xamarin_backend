using System;
using System.Linq;
using LeagueApp_xamarin_backend.Data;

namespace LeagueApp_xamarin_backend.Helpers
{
    public class UniqueCodeGenerator
    {
        private readonly MyDbContext _dbContext; // Your database context

        public UniqueCodeGenerator(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public string GenerateUniqueCode(int codeLength)
        {
            const string alphabet = "ABCDEFGHJKLMNPQRSTUVWXYZ23456789";
            var random = new Random();

            string code;
            do
            {
                code = new string(Enumerable.Repeat(alphabet, codeLength)
                                        .Select(s => s[random.Next(s.Length)]).ToArray());
            } while (IsCodeInUse(code));

            return code;
        }

        private bool IsCodeInUse(string code)
        {
            // Check if the code exists in either leagues or teams table
            // This is just a pseudocode, adjust the query according to your database structure
            return _dbContext.Leagues.Any(l => l.UniqueCode == code) || _dbContext.Teams.Any(t => t.UniqueCode == code);
        }
    }
}