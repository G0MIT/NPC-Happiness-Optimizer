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

    public bool addBiome(Biome biome)
    {
      if (!biome.IsCompatible(this))
      {
        return false;
      }
      Biomes.Add(biome);
      return true;
    }

    public bool addNpc(Npc npc)
    {
      Npcs.Add(npc);
      npc.CurrentLocation = this;
      return true;
    }

    public override string ToString() {
      string result = "Biomes: ";
      foreach(Biome biome in Biomes) {
        result += biome.Name + " ";
      }
      result += "\nNPCs:";
      foreach(Npc npc in Npcs) {
        result += "\n" + npc.Name;
      }
      return result;
    }
  }
}