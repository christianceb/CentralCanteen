namespace CentralCanteen
{
  /// <summary>
  /// Class for holding pizza topping size, name and its localized price. Class used when binding to ListBoxes
  /// </summary>
  public class PizzaToppingSize
  {
    public string Name { get; set; }
    public int Price;
    public string LocalizedPrice { get; set; }
  }
}
