using System.Collections.Generic;

namespace CentralCanteen
{
  public class Cart
  {
    private int Total = 0;
    public string LocalizedTotal { get => GetLocalizedTotal(); }
    public List<OrderItem> OrderItems = new List<OrderItem>();

    public void AddToCart(OrderItem OrderItem)
    {
      this.OrderItems.Add(OrderItem);
      Total += OrderItem.Total;
    }

    public void RemoveFromCart(OrderItem OrderItem)
    {
      OrderItems.Remove(OrderItem);
      RefreshTotals();
    }

    public bool FindInCart(FoodItem PinFoodItem)
    {
      bool Found = false;

      foreach (OrderItem OrderItem in OrderItems)
      {
        if (OrderItem.FoodItem == PinFoodItem)
        {
          Found = true;
          break;
        }
      }

      return Found;
    }

    public void Clear()
    {
      OrderItems.Clear();
      RefreshTotals();
    }

    public void RefreshTotals()
    {
      int NewTotal = 0;
      foreach (OrderItem OrderItem in OrderItems)
      {
        NewTotal += OrderItem.Total;
      }

      Total = NewTotal;
    }

    public string GetLocalizedTotal()
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
  }
}