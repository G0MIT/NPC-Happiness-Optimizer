using System;
using System.Collections.Generic;

public class Biome
{
    public string Name { get; }
    public List<string> IncompatibleBiomes { get; }

    public Biome(string name, List<string> incompatibleBiomes){
        Name = name;
        IncompatibleBiomes = incompatibleBiomes;
    }

    public bool isCompatible(Biome biome){
        return !IncompatibleBiomes.Contains(biome.Name);
    }

    public bool isCompatible(Location location){
        return location.Biomes.TrueForAll(biome => isCompatible(biome));
    }
}