using System.Collections.Generic;
namespace HappinessOptimizer
{
    public class Solution
    {
        public List<Location> Locations { get; set; }

        public Solution()
        {
            Locations = new List<Location>();
        }

        public Solution(List<Location> locations)
        {
            Locations = locations;
        }
        public void SwapNpcs(Npc npc1, Npc npc2)
        {
            Location location1 = Locations.Find(l => l.Npcs.Contains(npc1));
            Location location2 = Locations.Find(l => l.Npcs.Contains(npc2));
            location1.Npcs.Remove(npc1);
            location2.Npcs.Remove(npc2);
            location1.AddNpc(npc2);
            location2.AddNpc(npc1);
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
        public Solution Clone()
        {
            Solution clone = new();
            foreach (Location location in Locations)
            {
                clone.Locations.Add(location.Clone());
            }
            return clone;
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