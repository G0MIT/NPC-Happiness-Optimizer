using System;
using System.Collections.Generic;
namespace HappinessOptimizer
{
    public class Biome
    {
        public string Name { get; }
        public string DisplayName { get; }
        public int Priority { get; }
        private readonly List<string> IncompatibleBiomes;

        public Biome(string name, string displayName, int priority, List<string> incompatibleBiomes)
        {
            Name = name;
            DisplayName = displayName;
            Priority = priority;
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

        public override string ToString()
        {
            return DisplayName;
        }
    }
}