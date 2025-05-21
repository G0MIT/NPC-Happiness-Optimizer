using System;
using System.Collections.Generic;
using HappinessOptimizer;
class Program {
    public static void Main(string[] args) {
        Biome snow = new("Snow", new List<string>{"Ocean","Desert","Jungle"});
        Biome desert = new("Desert", new List<string>{"Ocean","Snow","Jungle"});
        Location location = new(new List<Biome>{snow});
        Console.WriteLine(desert.IsCompatible(location));
    }
}