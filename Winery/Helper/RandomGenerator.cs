using RandomNameGeneratorLibrary;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Winery.Helper
{
    public static class RandomGenerator
    {
        public static string GenerateClientName()
        {
            var personGenerator = new PersonNameGenerator();
            return personGenerator.GenerateRandomFirstAndLastName();
        }

        public static DateTime GenerateRandomDate(DateTime startDate, DateTime endDate)
        {
            Random random = new Random();
            int range = (endDate - startDate).Days;
            int randomDays = random.Next(range);
            return startDate.AddDays(randomDays);
        }

        public static string GenerateRandomGender()
        {
            Random random = new Random();
            int randomNumber = random.Next(2); // Generates 0 or 1

            if (randomNumber == 0)
            {
                return "male";
            }
            else
            {
                return "female";
            }
        }

        public static int GenerateRandomCountry()
        {
            var countryIds = DatabaseCommandHelper.GetCountryIds();
            if (countryIds == null || countryIds.Count == 0)
            {
                throw new ArgumentException("The list is empty or null.");
            }

            Random random = new Random();
            int randomIndex = random.Next(0, countryIds.Count);
            return countryIds[randomIndex];
        }

        public static int GetRandomWineFromList(List<int> wines)
        {
            Random random = new Random();
            int randomIndex = random.Next(0, wines.Count); 
            return wines[randomIndex];
        }

        public static int GenerateRandomNumber(decimal maxQuantity)
        {
            Random random = new Random();
            return random.Next(1, (int)maxQuantity + 1);
        }

        internal static int GenerateRandomNumberBetween(decimal minValue, decimal maxValue)
        {
            Random random = new Random();
            return random.Next((int)minValue, (int)maxValue + 1); 
        }
    }
}
