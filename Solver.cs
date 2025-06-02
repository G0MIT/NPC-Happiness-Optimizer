using System;
using System.Collections.Generic;
namespace HappinessOptimizer
{
    public class Solver
    {
        private Solution BestSolution;
        private readonly List<Npc> Npcs;
        private readonly List<Biome> Biomes;

        public Solver(List<Npc> npcs, List<Biome> biomes)
        {
            Npcs = npcs;
            Biomes = biomes;
            BestSolution = GenerateStartingSolution();
        }

        public Solution Solve()
        {
            // TODO: Implement solve
            return BestSolution;
        }

        public Solution GenerateStartingSolution()
        {
            Solution solution = new();
            for (int npcIndex = 0; npcIndex < Npcs.Count; npcIndex++)
            {
                Console.WriteLine("Adding NPC " + Npcs[npcIndex].DisplayName + " to the solution");
                Console.WriteLine("Added new blank location to the list of locations");
                solution.Locations.Add(new Location());
                double bestScore = int.MinValue;
                int indexToModify = 0;
                Biome bestBiome = null;
                for (int locationIndex = 0; locationIndex < solution.Locations.Count; locationIndex++)
                {
                    double score = solution.Locations[locationIndex].Score(Npcs[npcIndex]);
                    Biome biomeToAdd = null;

                    // Test loved biomes for this location
                    foreach (string biomeName in Npcs[npcIndex].LovedBiomes)
                    {
                        Biome biome = Biomes.Find(b => b.Name == biomeName);
                        if (biome != null && biome.IsCompatible(solution.Locations[locationIndex]))
                        {
                            double hybridScore = solution.Locations[locationIndex].Score(Npcs[npcIndex], biome);
                            if (hybridScore > score)
                            {
                                score = hybridScore;
                                biomeToAdd = biome;
                            }
                        }
                    }

                    // Test liked biomes for this location
                    foreach (string biomeName in Npcs[npcIndex].LikedBiomes)
                    {
                        Biome biome = Biomes.Find(b => b.Name == biomeName);
                        if (biome != null && biome.IsCompatible(solution.Locations[locationIndex]))
                        {
                            double hybridScore = solution.Locations[locationIndex].Score(Npcs[npcIndex], biome);
                            if (hybridScore > score)
                            {
                                score = hybridScore;
                                biomeToAdd = biome;
                            }
                        }
                    }
                    Console.WriteLine("Score for location with index " + locationIndex + " is " + score);
                    if (score >= bestScore)
                    {
                        bestScore = score;
                        indexToModify = locationIndex;
                        bestBiome = biomeToAdd;
                    }
                }
                solution.Locations[indexToModify].AddNpc(Npcs[npcIndex]);
                solution.Locations[indexToModify].AddBiome(bestBiome);
                // if (bestBiome != null)
                // {
                //     Console.WriteLine(bestBiome + " " + Npcs[npcIndex] + " " + bestScore);
                // }
                // else
                // {
                //     Console.WriteLine("No biome");
                // }
                if (indexToModify != solution.Locations.Count - 1)
                {
                    solution.Locations.RemoveAt(solution.Locations.Count - 1);
                }
            }
            return solution;
        }

        public List<Solution> GenerateNearestSolutions()
        {
            // TODO: Implement generateNearestSolutions
            return new List<Solution>();
        }


    }
}