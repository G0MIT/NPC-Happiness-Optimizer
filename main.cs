using System;
using System.Collections.Generic;
using HappinessOptimizer;

class Program
{
    public static void Main(string[] args)
    {
        List<Npc> npcs = new List<Npc>
        {
            new Npc("Angler", 90, null, new string[]{""}, new string[]{"Princess","Party Girl","Demolitionist","Tax Collector"}, new string[]{""}, new string[]{"Tavernkeep"}, new string[]{""}, new string[]{"Ocean"}, new string[]{"Desert"}, new string[]{""}),
            new Npc("Goblin Tinkerer", 100, null, new string[]{"Mechanic"}, new string[]{"Princess","Dye Trader"}, new string[]{"Clothier"}, new string[]{"Stylist"}, new string[]{""}, new string[]{"Underground"}, new string[]{"Jungle"}, new string[]{""})
        };
        List<Biome> biomes = new List<Biome>
        {
            new Biome("Ocean", new List<string>{"Desert"}),
            new Biome("Desert", new List<string>{"Ocean"}),
            new Biome("Underground", new List<string>{""})
        };
        Solver solver = new Solver(npcs, biomes);
        Solution solution = solver.Solve();
        Console.WriteLine("\n");
        Console.WriteLine(solution);
        Console.WriteLine(solution.Score());
    }
}