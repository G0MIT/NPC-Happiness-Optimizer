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
      BestSolution = GenerateStartingSolution();
      Npcs = npcs;
      Biomes = biomes;
    }
    
    public Solution Solve()
    {
      // TODO: Implement solve
      return BestSolution;
    }
    
    public Solution GenerateStartingSolution()
    {
      Solution solution = new();
      for (int npcIndex = 0; npcIndex < Npcs.Count; npcIndex++) {
        int bestLocationIndex = 0;
        int bestScore = int.MinValue;
        for (int locationIndex = 0; locationIndex < solution.Locations.Count; locationIndex++) {
          Location tempSolution = solution.Locations[locationIndex].Clone();
          tempSolution.addNpc(Npcs[npcIndex]);
          if (tempSolution.Score() > bestScore) {
            bestScore = tempSolution.Score();
            bestLocationIndex = locationIndex;
          }
        }
        if () {
          
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