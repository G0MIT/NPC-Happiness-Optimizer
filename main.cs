using System;
using System.Collections.Generic;

class Program {
    public static void Main(string[] args) {
        Biome snow = new Biome("Snow", new List<string>{"Ocean","Desert","Jungle"});
        Biome desert = new Biome("Desert", new List<string>{"Ocean","Snow","Jungle"});
        Console.WriteLine(snow.isCompatible(desert));
    }
}