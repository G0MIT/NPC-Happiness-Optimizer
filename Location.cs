using System;
using System.Collections.Generic;
namespace HappinessOptimizer
{
    public class Location
    {
        public List<Biome> Biomes { get; private set; }
        public List<Npc> Npcs { get; private set; }

        public Location()
        {
            Biomes = new();
            Npcs = new();
        }

        public Location(List<Biome> biomes, List<Npc> npcs)
        {
            Biomes = biomes;
            Npcs = npcs;
        }

        public Location Clone()
        {
            return new Location(new List<Biome>(Biomes), new List<Npc>(Npcs));
        }

        public bool AddBiome(Biome biome)
        {
            if (biome == null || !biome.IsCompatible(this))
            {
                return false;
            }
            Biomes.Add(biome);
            return true;
        }

        public bool AddNpc(Npc npc)
        {
            Npcs.Add(npc);
            npc.CurrentLocation = this;
            return true;
        }

        public double Score()
        {
            double result = 0;
            foreach (Npc npc in Npcs)
            {
                result += npc.Score();
            }
            return result;
        }

        public double Score(Npc npc)
        {
            Location location = Clone();
            location.AddNpc(npc.Clone());
            return location.Score() - Score();
        }

        public double Score(Biome biome)
        {
            Location location = Clone();
            location.AddBiome(biome);
            return location.Score() - Score();
        }

        public double Score(Npc npc, Biome biome)
        {
            Location location = Clone();
            location.AddNpc(npc.Clone());
            location.AddBiome(biome);
            return location.Score() - Score();
        }

        public override string ToString()
        {
            string result = "Biomes: ";
            Biomes.Sort((a, b) => a.Priority.CompareTo(b.Priority));
            foreach (Biome biome in Biomes)
            {
                result += biome + " ";
            }
            result += "\nNPCs:";
            foreach (Npc npc in Npcs)
            {
                result += "\n" + npc.DisplayName;
            }
            return result;
        }
    }
}