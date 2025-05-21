using System;
using System.Collections.Generic;
namespace HappinessOptimizer
{
  public class Solver
  {

    private Solution bestSolution;

    public Solver()
    {
      bestSolution = GenerateStartingSolution();
    }

    public Solution GenerateStartingSolution()
    {
      // TODO: Implement generateStartingSolution
      return new Solution(new List<Location>());
    }

    public List<Solution> GenerateNearestSolutions()
    {
      // TODO: Implement generateNearestSolutions
      return new List<Solution>();
    }


  }
}