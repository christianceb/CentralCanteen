using System;
using System.Collections.Generic;

namespace CentralCanteen
{
  public class Order
  {
    public DateTime Date;
    public string Name;
    public string Phone;
    public string Address;

    private int Total = 0;
    public Delivery Delivery;
    public string LocalizedTotal { get => GetLocalizedTotal(); }
    public List<OrderItem> Items { get; }

    public Order( List<OrderItem> Items )
    {
      this.Items = Items;
    }

    public void SetDelivery(Delivery Delivery)
    {
      this.Delivery = Delivery;
      RefreshTotals();
    }

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

    public string GetLocalizedDelivery()
    {
      return Delivery.GetLocalized();
    }

    public void CheckoutDateNow()
    {
      Date = DateTime.Now;
    }
  }
}
