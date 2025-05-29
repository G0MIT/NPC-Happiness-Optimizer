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
                solution.Locations.Add(new Location());
                double bestScore = int.MinValue;
                int indexToModify = 0;
                Biome bestBiome = null;
                for (int locationIndex = 0; locationIndex < solution.Locations.Count; locationIndex++)
                {
                    double score = solution.Locations[locationIndex].Score(Npcs[npcIndex]);
                    Biome biomeToAdd = null;

                    foreach (string biomeName in Npcs[npcIndex].LovedBiomes)
                    {
                        if (String.IsNullOrEmpty(biomeName))
                        {
                            continue;
                        }
                        Biome biome = Biomes.Find(b => b.Name == biomeName);
                        double hyrbridScore = solution.Locations[locationIndex].Score(Npcs[npcIndex], biome);
                        if (hyrbridScore > score)
                        {
                            score = hyrbridScore;
                            biomeToAdd = biome;
                        }
                    }

                    foreach (string biomeName in Npcs[npcIndex].LikedBiomes)
                    {
                        if (String.IsNullOrEmpty(biomeName))
                        {
                            continue;
                        }
                        Biome biome = Biomes.Find(b => b.Name == biomeName);
                        double hyrbridScore = solution.Locations[locationIndex].Score(Npcs[npcIndex], biome);
                        if (hyrbridScore > score)
                        {
                            score = hyrbridScore;
                            biomeToAdd = biome;
                        }
                    }

                    if (score > bestScore)
                    {
                        bestScore = score;
                        indexToModify = locationIndex;
                        bestBiome = biomeToAdd;
                    }
                }
                solution.Locations[indexToModify].addNpc(Npcs[npcIndex]);
                solution.Locations[indexToModify].addBiome(bestBiome);
                // if (bestBiome != null)
                // {
                //     Console.WriteLine(bestBiome);
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