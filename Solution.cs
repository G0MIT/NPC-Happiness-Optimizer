using System.Collections.Generic;
namespace HappinessOptimizer
{
    public class Solution
    {
        public List<Location> Locations { get; private set; }

        public Solution()
        {
            Locations = new List<Location>();
        }

        public Solution(List<Location> locations)
        {
            Locations = locations;
        }

        public double Score()
        {
            double result = 0;
            foreach (Location location in Locations)
            {
                result += location.Score();
            }
            return result;
        }

        public override string ToString()
        {
            string result = "";
            foreach (Location location in Locations)
            {
                result += location.ToString();
                result += "\n\n";
            }
            return result;
        }
    }
}