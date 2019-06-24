using System;

namespace CentralCanteen
{
  /// <summary>
  /// Base class for food items shown in the menu.
  /// </summary>
  public class FoodItem : Money, IEquatable<FoodItem>
  {
    public string Name { get; set; }
    public string InvoiceName { get => GetInvoiceName(); }
    public string Category { get; set; }
    public string Info { get; set; }
    public int Price { get; set; }
    public string MenuPrice { get => GetMenuPrice(); }

    /// <summary>
    /// Gets the localized version of the price.
    /// </summary>
    /// <returns>The price of this FoodItem in human readable format.</returns>
    public string GetMenuPrice()
    {
      return Localize(Price);
    }

    /// <summary>
    /// Sets the FoodItem object to be comparable to other similar objects. Useful when matching with objects with similar names and categories
    /// </summary>
    /// <param name="other">True if both FoodItems match. Otherwise, false.</param>
    /// <returns></returns>
    public bool Equals(FoodItem other)
    {
      if (this.Name == other.Name && this.Category == other.Category)
      {
        return true;
      }

      return false;
    }

    /// <summary>
    /// Get the defined invoice name for this food item.
    /// </summary>
    /// <returns>The name in the invoice when printed in all caps.</returns>
    public virtual string GetInvoiceName()
    {
      // All caps so the name is INTENSE
      return Name.ToUpper();
    }
  }
}
