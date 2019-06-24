using System;

namespace CentralCanteen
{
  /// <summary>
  /// Wraps a FoodItem into an OrderItem, usually containing input from a customer such as quantity (not in use, but can be extended)
  /// </summary>
  public class OrderItem : Money, IEquatable<OrderItem>
  {
    public FoodItem FoodItem;
    private int Quantity;
    public string Name { get => GetName(); }
    public string InvoiceName { get => GetInvoiceName(); }
    public string Info { get => GetInfo(); }
    public int Total { get => GetTotal(); }
    public string LocalizedSubtotal { get => GetLocalizedSubtotal(); }

    /// <summary>
    /// Creates the OrderItem for a specified FoodItem
    /// </summary>
    /// <param name="FoodItem">The FoodItem to be wrapped as an OrderItem.</param>
    /// <param name="Quantity">The quantity to be set on this order item of this food item. Can be omitted and defaults to 1</param>
    public OrderItem(FoodItem FoodItem, int Quantity = 1)
    {
      this.FoodItem = FoodItem;
      this.Quantity = Quantity;
    }

    /// <summary>
    /// Gets the subtotal of this OrderItem given the FoodItem price and the set quantity. Machine readable only.
    /// </summary>
    /// <returns>The subtotal of this OrderItem</returns>
    public int GetTotal()
    {
      return FoodItem.Price * Quantity;
    }

    /// <summary>
    /// Gets the name of the FoodItem associated to this OrderItem.
    /// </summary>
    /// <returns>The name of the FoodItem. No processing added.</returns>
    public string GetName()
    {
      return FoodItem.Name;
    }

    /// <summary>
    /// Allows an OrderItem to be comparable with other OrderItem objects. Only matches the name and the total.
    /// </summary>
    /// <param name="other">The other OrderItem to match to this instance of OrderItem</param>
    /// <returns>Returns true if both objects match given the criteria (yes, still has a chance of not being identical). Otherwise, false.</returns>
    public bool Equals(OrderItem other)
    {
      if (this.Name == other.Name && this.Total == other.Total)
      {
        return true;
      }

      return false;
    }

    /// <summary>
    /// Returns the human readable total of this order item.
    /// </summary>
    /// <returns>The human readable total of this order item.</returns>
    public string GetLocalizedSubtotal()
    {
      return Localize(Total);
    }

    /// <summary>
    /// The name of this OrderItem when printed in the invoice.
    /// </summary>
    /// <returns></returns>
    public string GetInvoiceName()
    {
      return FoodItem.InvoiceName;
    }

    /// <summary>
    /// Gets the info of this particular OrderItem, normally related to the name. Very useful when keeping information of toppings/size of the pizza.
    /// </summary>
    /// <returns>The info of this OrderItem</returns>
    public string GetInfo()
    {
      return FoodItem.Info;
    }
  }
}