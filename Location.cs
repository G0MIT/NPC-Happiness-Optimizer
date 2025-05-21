using System;
using System.Collections.Generic;
namespace HappinessOptimizer
{
  public class Location
  {
    public List<Biome> Biomes { get; }
    public List<NPC> NPCs { get; }
    public Location(List<Biome> biomes)
    {
      Biomes = biomes;
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

    public bool addNpc(NPC npc)
    {
      NPCs.Add(npc);
      npc.CurrentLocation = this;
      return true;
    }
  }
}