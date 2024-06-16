namespace NewBegin.Infrastructure
{
    internal static class UserIDGenerator
    {
        private static readonly Random random = new Random();
        private const string chars = "abcdefghijklmnopqrstuvwxyz0123456789";
        private const int idLength = 5;

        public static string GenerateID()
        {
            return new string(Enumerable.Repeat(chars, idLength)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
