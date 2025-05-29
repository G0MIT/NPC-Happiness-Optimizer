using System;
using System.Collections.Generic;
using HappinessOptimizer;

class Program
{
    public static void Main(string[] args)
    {
        List<Npc> npcs = new List<Npc>
        {
            new Npc("angler", "Angler", 90, null, new string[]{""}, new string[]{"princess","party","demo","tax"}, new string[]{""}, new string[]{"tavern"}, new string[]{""}, new string[]{"ocean"}, new string[]{"desert"}, new string[]{""}),
            new Npc("tinkerer", "Goblin Tinkerer", 100, null, new string[]{"mechanic"}, new string[]{"princess","dye"}, new string[]{"clothier"}, new string[]{"stylist"}, new string[]{""}, new string[]{"underground"}, new string[]{"jungle"}, new string[]{""})
        };
        List<Biome> biomes = new List<Biome>
        {
            new Biome("ocean", "Ocean", 3, new List<string>{"Desert"}),
            new Biome("desert", "Desert", 3, new List<string>{"Ocean"}),
            new Biome("hallow", "Hallowed", 2, new List<string>{""}),
            new Biome("underground", "Underground", 1, new List<string>{""})
        };
        foreach (Npc npc in npcs) {
            Console.WriteLine("Please input a value for the following NPC:\n" + npc.DisplayName);
            string input = Console.ReadLine();
            int value;
            
            while (!int.TryParse(input, out value)) {
                Console.WriteLine("Please input a valid value for the following NPC: " + npc.DisplayName);
                input = Console.ReadLine();
            }
            npc.Value = value;
        }
        npcs.Sort((a, b) => b.Value.CompareTo(a.Value));
        
        Solver solver = new Solver(npcs, biomes);
        Solution solution = solver.Solve();
        Console.WriteLine("\n" + npcs[0]);
        Console.WriteLine(npcs[1] + "\n");
        
        Console.WriteLine(solution);
        Console.WriteLine("Total score for this solution: " + solution.Score());
    }
}