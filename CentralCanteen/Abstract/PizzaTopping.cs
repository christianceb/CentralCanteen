using System.Collections.Generic;

namespace CentralCanteen
{
  /// <summary>
  /// Class for holding pizza topping name and the sizes being used. Class used when binding to ListBoxes
  /// </summary>
  public class PizzaTopping
  {
    public string Name { get; set; }
    public List<PizzaToppingSize> Sizes = new List<PizzaToppingSize>();
  }
}
