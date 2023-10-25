using OxyPlot;
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
        static Random random = new Random();

        public static string GenerateClientName()
        {
            var personGenerator = new PersonNameGenerator();
            return personGenerator.GenerateRandomFirstAndLastName();
        }
        
        public static OxyColor GetRandomColor()
        {

            byte red = (byte)random.Next(256); // Generate a random value between 0 and 255 for red
            byte green = (byte)random.Next(256); // Generate a random value between 0 and 255 for green
            byte blue = (byte)random.Next(256); // Generate a random value between 0 and 255 for blue

            return OxyColor.FromRgb(red, green, blue);
        }

        public static DateTime GenerateRandomDate(DateTime startDate, DateTime endDate)
        {
            int range = (endDate - startDate).Days;
            int randomDays = random.Next(range);
            return startDate.AddDays(randomDays);
        }

        public static string GenerateRandomGender()
        {
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

            int randomIndex = random.Next(0, countryIds.Count);
            return countryIds[randomIndex];
        }

        public static int GetRandomWineFromList(List<int> wines)
        {
            int randomIndex = random.Next(0, wines.Count); 
            return wines[randomIndex];
        }

        public static int GenerateRandomNumber(decimal maxQuantity)
        {
            return random.Next(1, (int)maxQuantity + 1);
        }

        internal static int GenerateRandomNumberBetween(decimal minValue, decimal maxValue)
        {
            return random.Next((int)minValue, (int)maxValue + 1); 
        }
    }
}
