using System;
using System.Collections.Generic;
namespace HappinessOptimizer
{
    public class Biome
    {
        public string Name { get; }
        private readonly List<string> IncompatibleBiomes;

        public Biome(string name, List<string> incompatibleBiomes)
        {
            Name = name;
            IncompatibleBiomes = incompatibleBiomes;
        }

        public bool IsCompatible(Biome biome)
        {
            return !IncompatibleBiomes.Contains(biome.Name);
        }

        public bool IsCompatible(Location location)
        {
            return location.Biomes.TrueForAll(IsCompatible);
        }

    }
}