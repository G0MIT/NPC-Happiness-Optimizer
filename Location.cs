using System;
using System.Collections.Generic;

public class Location {
  public List<Biome> Biomes {get;}
  public List<NPC> NPCs {get;}
  public Location(List<Biome> biomes) {
    Biomes = biomes;
  }

  public bool addBiome(Biome biome) {
    return false;
  }
}