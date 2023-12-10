

namespace LeagueApp_xamarin_backend.Helpers
{
    public class UniqueCodeGenerator
    {
        private static readonly Random random = new Random();

        public static string GenerateUniqueCode(int length)
        {
            // Characters that are less likely to be confused with one another
            const string chars = "ABCDEFGHJKLMNPQRSTUVWXYZ23456789";
            return new string(Enumerable.Repeat(chars, length)
            .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}