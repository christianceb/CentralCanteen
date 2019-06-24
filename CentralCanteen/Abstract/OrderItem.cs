using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentralCanteen
{
  public class OrderItem : IEquatable<OrderItem>
  {
    public FoodItem FoodItem;
    private int Quantity;
    public string Name { get => GetName(); }
    public string InvoiceName { get => GetInvoiceName(); }
    public string Info;
    public int Total { get => GetTotal(); }
    public string LocalizedSubtotal { get => GetSubtotal(); }
    
    public OrderItem( FoodItem FoodItem, int Quantity )
    {
      this.FoodItem = FoodItem;
      this.Quantity = Quantity;
    }

    public int GetTotal()
    {
      return FoodItem.Price * Quantity;
    }

    public string GetName()
    {
      return FoodItem.Name;
    }

    public bool Equals(OrderItem other)
    {
      if ( this.Name == other.Name && this.Total == other.Total )
      {
        return true;
      }

      return false;
    }

    public string GetSubtotal()
    {
      string FinalTotal = "0.00";
      string StringCents = "00";
      int WholeNumberTotal = Total / 100;
      int Cents = Total % 100;

      if (Cents > 0 && Cents < 10)
      {
        StringCents = "0" + Cents.ToString();
      }
      else if (Cents >= 10)
      {
        StringCents = Cents.ToString();
      }

      FinalTotal = "$" + WholeNumberTotal.ToString() + "." + StringCents;

      return FinalTotal;
    }

    public string GetInvoiceName()
    {
      return FoodItem.InvoiceName;
    }
  }
}