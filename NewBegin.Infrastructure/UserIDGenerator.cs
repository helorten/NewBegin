namespace NewBegin.Infrastructure
{
    internal static class UserIDGenerator
    {
        private static readonly Random Random = new Random();

        public static string GenerateID()
        {
            DateTime currentDate = DateTime.Now;
            long timestamp = currentDate.Millisecond;
            int randomPart = Random.Next(10000, 99999);

            return $"{timestamp}{randomPart}";
        }
    }
}
