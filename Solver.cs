using System;
using System.Collections.Generic;
namespace HappinessOptimizer
{
    public class Solver
    {
        private const int RunCount = 1000;
        private List<Solution> BestSolutions;
        private readonly Solution StartingSolution;
        private readonly List<Npc> Npcs;
        private readonly List<Biome> Biomes;

        public Solver(List<Npc> npcs, List<Biome> biomes)
        {
            Npcs = npcs;
            Biomes = biomes;
            StartingSolution = GenerateStartingSolution();
            BestSolutions = new List<Solution>();
        }

        public Solution Solve()
        {
            // TODO: Implement solve
            Solution bestSolution = StartingSolution;
            Solution currentSolution = StartingSolution;
            List<Solution> previousSolutions = new();
            for (int i = 0; i < RunCount; i++)
            {
                Solution nextSolution = null;
                List<Solution> nearestSolutions = GenerateNearestSolutions(currentSolution);
                double bestScore = currentSolution.Score();
                foreach (Solution solution in nearestSolutions)
                {
                    if (solution.Score() > bestScore)
                    {
                        nextSolution = solution;
                        bestScore = solution.Score();
                    }
                }
                if (nextSolution == null)
                {
                    Random random = new();
                    do
                    {
                        nextSolution = nearestSolutions[random.Next(0, nearestSolutions.Count)];
                    } while (previousSolutions.Contains(nextSolution));
                }
                if (nextSolution.Score() > bestScore)
                {
                    bestSolution = nextSolution;
                }
                currentSolution = nextSolution;
            }
            return bestSolution;
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
                        double hybridScore = solution.Locations[locationIndex].Score(Npcs[npcIndex], biome);
                        if (hybridScore > score)
                        {
                            score = hybridScore;
                            biomeToAdd = biome;
                        }
                    }

                    // Test liked biomes for this location
                    foreach (string biomeName in Npcs[npcIndex].LikedBiomes)
                    {
                        Biome biome = Biomes.Find(b => b.Name == biomeName);
                        double hybridScore = solution.Locations[locationIndex].Score(Npcs[npcIndex], biome);
                        if (hybridScore > score)
                        {
                             score = hybridScore;
                            biomeToAdd = biome;
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
                Console.WriteLine("Adding " + Npcs[npcIndex].DisplayName + " to the location with index " + indexToModify);
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

        public List<Solution> GenerateNearestSolutions(Solution baseSolution)
        {
            List<Solution> nearestSolutions = new();
            for (int i = 0; i < Npcs.Count; i++)
            {
                for (int j = i + 1; j < Npcs.Count; j++)
                {
                    Solution solution = baseSolution.Clone();
                    solution.SwapNpcs(Npcs[i], Npcs[j]);
                    nearestSolutions.Add(solution);
                }
            }
            for (int i = 0; i < baseSolution.Locations.Count; i++)
            {
                for (int j = 0; j < Biomes.Count; j++)
                {
                    Solution solution = baseSolution.Clone();
                    if (solution.Locations[i].AddBiome(Biomes[j]))
                    {
                        nearestSolutions.Add(solution);
                    }
                }
            }
            
            return nearestSolutions;
        }


    }
}