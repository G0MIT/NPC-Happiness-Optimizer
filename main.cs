using System;
using System.Collections.Generic;
using HappinessOptimizer;

class Program
{
    public static void Main(string[] args)
    {
        List<Npc> npcs = new List<Npc>
        {
            new Npc("angler", "Angler", 90, null, new string[]{""}, new string[]{"Princess","Party Girl","Demolitionist","Tax Collector"}, new string[]{""}, new string[]{"Tavernkeep"}, new string[]{""}, new string[]{"Ocean"}, new string[]{"Desert"}, new string[]{""}),
            new Npc("Goblin Tinkerer", 100, null, new string[]{"Mechanic"}, new string[]{"Princess","Dye Trader"}, new string[]{"Clothier"}, new string[]{"Stylist"}, new string[]{""}, new string[]{"Underground"}, new string[]{"Jungle"}, new string[]{""})
        };
        List<Biome> biomes = new List<Biome>
        {
            new Biome("ocean", 3, new List<string>{"Desert"}),
            new Biome("desert", "Desert" 3, new List<string>{"Ocean"}),
            new Biome("hallow", "Hallowed", 2, new List<string>{""}),
            new Biome("underground", 1, new List<string>{""})
        };
        Solver solver = new Solver(npcs, biomes);
        Solution solution = solver.Solve();
        Console.WriteLine("\n");
        Console.WriteLine(solution);
        Console.WriteLine(solution.Score());
    }
}