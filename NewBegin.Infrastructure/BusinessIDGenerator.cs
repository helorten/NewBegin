using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewBegin.Infrastructure
{
    internal static class BusinessIDGenerator
    {
        private static readonly Random random = new Random();

        public static string GenerateID(string businessCountryLocation)
        {
            DateTime currentDate = DateTime.Now;
            long timestamp = currentDate.Millisecond;
            int randomPart = random.Next(10, 99);
            return $"{businessCountryLocation}:{timestamp}{randomPart}";
        }
    }
}
