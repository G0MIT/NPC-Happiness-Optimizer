using System;
using System.Collections.Generic;
using HappinessOptimizer;

class Program
{
    public static void Main(string[] args)
    {
        List<Npc> npcs = new List<Npc>
        {
            new Npc("angler", "Angler", new string[]{}, new string[]{"princess","party","demo","tax"}, new string[]{}, new string[]{"tavern"}, new string[]{}, new string[]{"ocean"}, new string[]{"desert"}, new string[]{}),
            new Npc("arms", "Arms Dealer", new string[]{"nurse"}, new string[]{"princess","steampunker"}, new string[]{"golfer"}, new string[]{"demo"}, new string[]{}, new string[]{"desert"}, new string[]{"snow"}, new string[]{}),
            new Npc("clothier", "Clothier", new string[]{"truffle"}, new string[]{"princess","tax"}, new string[]{"nurse"}, new string[]{"mechanic"}, new string[]{}, new string[]{"underground"}, new string[]{"hallow"}, new string[]{}),
            new Npc("cyborg", "Cyborg", new string[]{}, new string[]{"princess","stylist","pirate","steampunker"}, new string[]{"zoo"}, new string[]{"wiz"}, new string[]{}, new string[]{"snow"}, new string[]{"jungle"}, new string[]{}),
            new Npc("demo", "Demolitionist", new string[]{"Tavernkeep"}, new string[]{"princess","mechanic"}, new string[]{"tinkerer","arms"}, new string[]{}, new string[]{}, new string[]{"underground"}, new string[]{"ocean"}, new string[]{}),
            new Npc("dryad", "Dryad", new string[]{}, new string[]{"princess","witch","truffle"}, new string[]{"angler"}, new string[]{"golfer"}, new string[]{}, new string[]{"jungle"}, new string[]{"desert"}, new string[]{}),
            new Npc("dye", "Dye Trader", new string[]{}, new string[]{"princess","arms","painter"}, new string[]{"steampunker"}, new string[]{"pirate"}, new string[]{}, new string[]{"desert"}, new string[]{"forest"}, new string[]{}),
            new Npc("tinkerer", "Goblin Tinkerer", new string[]{"mechanic"}, new string[]{"princess","dye"}, new string[]{"clothier"}, new string[]{"stylist"}, new string[]{}, new string[]{"underground"}, new string[]{"jungle"}, new string[]{}),
            new Npc("golfer", "Golfer", new string[]{"angler"}, new string[]{"princess","painter","zoo"}, new string[]{"pirate"}, new string[]{"merchant"}, new string[]{}, new string[]{"forest"}, new string[]{"underground"}, new string[]{}),
            new Npc("guide", "Guide", new string[]{}, new string[]{"princess","clothier","zoologst"}, new string[]{"steampunker"}, new string[]{"painter"}, new string[]{}, new string[]{"forest"}, new string[]{"ocean"}, new string[]{}),
            new Npc("mechanic", "Mechanic", new string[]{"tinkerer"}, new string[]{"princess","cyborg"}, new string[]{"arms"}, new string[]{"clothier"}, new string[]{}, new string[]{"snow"}, new string[]{"underground"}, new string[]{}),
            new Npc("merchant", "Merchant", new string[]{}, new string[]{"princess","golfer","nurse"}, new string[]{"tax"}, new string[]{"angler"}, new string[]{}, new string[]{"forest"}, new string[]{"desert"}, new string[]{}),
            new Npc("nurse", "Nurse", new string[]{"arms"}, new string[]{"princess","wiz"}, new string[]{"dryad","party"}, new string[]{"zoo"}, new string[]{}, new string[]{"hallow"}, new string[]{"snow"}, new string[]{}),
            new Npc("painter", "Painter", new string[]{"dryad"}, new string[]{"princess","party"}, new string[]{"cyborg","truffle"}, new string[]{}, new string[]{}, new string[]{"jungle"}, new string[]{"forest"}, new string[]{}),
            new Npc("party", "Party Girl", new string[]{"zoo","wiz"}, new string[]{"princess","stylist"}, new string[]{"merchant"}, new string[]{"tax"}, new string[]{}, new string[]{"hallow"}, new string[]{"underground"}, new string[]{}),
            new Npc("pirate", "Pirate", new string[]{"angler"}, new string[]{"princess","tavernkeep"}, new string[]{"stylist"}, new string[]{"guide"}, new string[]{}, new string[]{"ocean"}, new string[]{"underground"}, new string[]{}),
            new Npc("santa", "Santa Claus", new string[]{}, new string[]{"princess"}, new string[]{}, new string[]{"tax"}, new string[]{"snow"}, new string[]{}, new string[]{}, new string[]{"desert"}),
            new Npc("steampunker", "Steampunker", new string[]{"cyborg"}, new string[]{"princess","painter"}, new string[]{"party","wiz","dryad"}, new string[]{}, new string[]{}, new string[]{"desert"}, new string[]{"jungle"}, new string[]{}),
            new Npc("stylist", "Stylist", new string[]{"dye"}, new string[]{"princess","pirate"}, new string[]{"tavernkeep"}, new string[]{"tinkerer"}, new string[]{}, new string[]{"ocean"}, new string[]{"snow"}, new string[]{}),
            new Npc("tavernkeep", "Tavernkeep", new string[]{"demo"}, new string[]{"princess","tinkerer"}, new string[]{"guide"}, new string[]{"dye"}, new string[]{}, new string[]{"hallow"}, new string[]{"snow"}, new string[]{}),
            new Npc("tax", "Tax Collector", new string[]{"merchant"}, new string[]{"princess","party"}, new string[]{"demo","mechanic"}, new string[]{"santa"}, new string[]{}, new string[]{"snow"}, new string[]{"hallow"}, new string[]{}),
            //probably truffle subclass
            new Npc("truffle", "Truffle", new string[]{"guide"}, new string[]{"princess","dryad"}, new string[]{"clothier"}, new string[]{"witch"}, new string[]{}, new string[]{"mushroom"}, new string[]{}, new string[]{}),
            new Npc("witch", "Witch Doctor", new string[]{}, new string[]{"princess","dryad","guide"}, new string[]{"nurse"}, new string[]{"truffle"}, new string[]{}, new string[]{"jungle"}, new string[]{"hallow"}, new string[]{}),
            new Npc("wiz", "Wizard", new string[]{"golfer"}, new string[]{"princess","merchant"}, new string[]{"witch"}, new string[]{"cyborg"}, new string[]{}, new string[]{"hallow"}, new string[]{}, new string[]{}),
            new Npc("zoo", "Zoologist", new string[]{"witch"}, new string[]{"princess","golfer"}, new string[]{"angler"}, new string[]{"arms"}, new string[]{}, new string[]{"forest"}, new string[]{"desert"}, new string[]{}),
        };
        List<Biome> biomes = new List<Biome>
        {
            new Biome("ocean", "Ocean", 3, new List<string>{"forest","desert"}),
            new Biome("desert", "Desert", 3, new List<string>{"forest","ocean","snow","jungle"}),
            new Biome("hallow", "Hallowed", 2, new List<string>{"forest"}),
            new Biome("underground", "Underground", 1, new List<string>{"forest"}),
            new Biome("jungle", "Jungle", 3, new List<string>{"forest","ocean","snow","desert"}),
            new Biome("snow", "Snow", 3, new List<string>{"forest","ocean","desert","jungle"}),
            new Biome("forest", "Forest", 3, new List<string>{"ocean","desert","hallow","underground","jungle","snow"}),
        };
        foreach (Npc npc in npcs)
        {
            Console.WriteLine("Please input a value for the following NPC:\n" + npc.DisplayName);
            string input = Console.ReadLine();
            int value;

            while (!int.TryParse(input, out value))
            {
                Console.WriteLine("Please input a valid value for the following NPC: " + npc.DisplayName);
                input = Console.ReadLine();
            }
            npc.Value = value;
        }
        npcs.Sort((a, b) => b.Value.CompareTo(a.Value));

        Solver solver = new Solver(npcs, biomes);
        Solution solution = solver.Solve();

        Console.WriteLine(solution);
        Console.WriteLine(solution.Locations[0].Npcs[0]);
        Console.WriteLine("Total score for this solution: " + solution.Score());
    }
}