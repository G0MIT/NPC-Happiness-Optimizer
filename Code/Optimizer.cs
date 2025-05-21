using System.Collections.Generic;

public class Optimizer {

  private Solution bestSolution;
  
  public Optimizer() {
    bestSolution = generateStartingSolution();
  }

  public Solution generateStartingSolution() {
    // TODO: Implement generateStartingSolution
    return new Solution(new List<Location>());
  }
  
  public List<Solution> generateNearestSolutions() {
    // TODO: Implement generateNearestSolutions
    return new List<Solution>();
  }
}