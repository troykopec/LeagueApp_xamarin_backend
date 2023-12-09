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
            code = new string(Enumerable.Repeat(alphabet, codeLength)
                                        .Select(s => s[random.Next(s.Length)]).ToArray());
            return code;
        }
    }
}