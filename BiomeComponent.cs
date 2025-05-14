using System.Collections.Generic;

public class BiomeComponent {
  private string Name {get; set;}
  private List<string> IncompatibleComponents {get;}
  
  public BiomeComponent(string name, List<string> incompatibleComponents) {
    this.Name = name;
    this.IncompatibleComponents = incompatibleComponents;
  }
  
  public bool isCompatible(BiomeComponent other) {


    return false;
  }
}