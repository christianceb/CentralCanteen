using System.Collections.Generic;

namespace CentralCanteen
{
  /// <summary>
  /// Cart holds a temporary storage of chosen items to be ordered. Think quote vs order. Does not hold any deliver capabilities.
  /// </summary>
  public class Cart : Money
  {
    private int Total = 0;
    public string LocalizedTotal { get => GetLocalizedTotal(); }
    public List<OrderItem> OrderItems = new List<OrderItem>();

    /// <summary>
    /// Adds an OrderItem to the Cart. Automatically update Cart Totals.
    /// </summary>
    /// <param name="OrderItem">The order item to be added</param>
    public void AddToCart(OrderItem OrderItem)
    {
      this.OrderItems.Add(OrderItem);
      Total += OrderItem.Total;
    }

    /// <summary>
    /// Removes an item in the cart given an OrderItem object that exists in the cart. Automatically updates Cart Totals.
    /// </summary>
    /// <param name="OrderItem">The OrderItem object to be deleted.</param>
    public void RemoveFromCart(OrderItem OrderItem)
    {
      OrderItems.Remove(OrderItem);
      RefreshTotals();
    }

    /// <summary>
    /// Finds an item in the cart given an OrderItem object to match it to.
    /// </summary>
    /// <param name="PinFoodItem">The OrderItem object to be searched.</param>
    /// <returns></returns>
    public bool FindInCart(FoodItem PinFoodItem)
    {
      bool Found = false;

      foreach (OrderItem OrderItem in OrderItems)
      {
        // FoodItems are comparable but only match it against the name and the category
        if (OrderItem.FoodItem == PinFoodItem)
        {
          Found = true;
          break;
        }
      }

      return Found;
    }

    /// <summary>
    /// Clears any data in the cart.
    /// </summary>
    public void Clear()
    {
      OrderItems.Clear();
      RefreshTotals();
    }

    /// <summary>
    /// Refresh totals in the cart. Useful in cases where adding an item to the cart does not trigger auto-update of totals which, you shouldn't be doing anyway. Use the API to add OrderItem into cart.
    /// </summary>
    public void RefreshTotals()
    {
      int NewTotal = 0;
      foreach (OrderItem OrderItem in OrderItems)
      {
        NewTotal += OrderItem.Total;
      }

      Total = NewTotal;
    }

    /// <summary>
    /// Get the Localized Total of a Total.
    /// </summary>
    /// <returns></returns>
    public string GetLocalizedTotal()
    {
      return Localize( Total );
    }
  }
}