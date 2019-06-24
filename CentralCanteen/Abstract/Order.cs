using System;
using System.Collections.Generic;

namespace CentralCanteen
{
  /// <summary>
  /// Collates the order items (usually from cart) and handles delivery, order and customer information.
  /// </summary>
  public class Order : Money
  {
    public Nullable<DateTime> Date = null;
    public string Name;
    public string Phone;
    public string Address;

    private int Total = 0;
    public Delivery Delivery;
    public string LocalizedTotal { get => GetLocalizedTotal(); }
    public List<OrderItem> Items { get; }

    /// <summary>
    /// Instantiates an Order object. Parameter should not be empty to have a meaningful result. Automatically refreshes totals.
    /// </summary>
    /// <param name="Items"></param>
    public Order( List<OrderItem> Items )
    {
      this.Items = Items;
      RefreshTotals();
    }

    /// <summary>
    /// Given a Delivery object defined, assigns it as the method of Delivery of this Order.
    /// </summary>
    /// <param name="Delivery"></param>
    public void SetDelivery(Delivery Delivery)
    {
      this.Delivery = Delivery;
      RefreshTotals();
    }

    /// <summary>
    /// Refreshes totals of the Order
    /// </summary>
    public void RefreshTotals()
    {
      int NewTotal = 0;
      foreach (OrderItem OrderItem in Items)
      {
        NewTotal += OrderItem.Total;
      }

      if (Delivery != null)
      {
        NewTotal += Delivery.Cost;
      }

      Total = NewTotal;
    }

    /// <summary>
    /// Returns a human readable total of this order
    /// </summary>
    /// <returns></returns>
    public string GetLocalizedTotal()
    {
      return Localize(Total);
    }

    /// <summary>
    /// Gets the localized delivery information of this order provided a Delivery method is set.
    /// </summary>
    /// <returns></returns>
    public string GetLocalizedDelivery()
    {
      return Delivery.GetLocalized();
    }

    /// <summary>
    /// Timestamps this order with the current date/time when invoked.
    /// </summary>
    public void CheckoutDateNow()
    {
      Date = DateTime.Now;
    }
  }
}
