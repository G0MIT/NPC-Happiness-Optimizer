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
      solution.Locations.Add(new Location(new List<Biome>()));
      return solution;
    }

    public List<Solution> GenerateNearestSolutions()
    {
      // TODO: Implement generateNearestSolutions
      return new List<Solution>();
    }


  }
}