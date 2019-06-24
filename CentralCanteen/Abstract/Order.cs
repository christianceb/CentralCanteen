using System;
using System.Collections.Generic;

namespace CentralCanteen
{
  public class Order
  {
    private DateTime Date;
    public string Name;
    public string Phone;
    public string Address;

    private int Total = 0;
    private Delivery Delivery;
    public string LocalizedTotal { get => GetLocalizedTotal(); }
    public List<OrderItem> OrderItems { get; }

    public Order( List<OrderItem> OrderItems )
    {
      this.OrderItems = OrderItems;

    }

    public void SetDelivery(Delivery Delivery)
    {
      this.Delivery = Delivery;
      RefreshTotals();
    }

    public void RefreshTotals()
    {
      int NewTotal = 0;
      foreach (OrderItem OrderItem in OrderItems)
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

    public string RenderOrderInvoice()
    {
      string InvoiceBody = "---CENTRAL CANTEEN ORDER INVOICE---\r\n\r\n";

      InvoiceBody += RenderOrderItems() + "\r\n";
      InvoiceBody += RenderDelivery() + "\r\n";
      InvoiceBody += RenderTotal() + "\r\n\r\n";

      InvoiceBody += "----THANK YOU. ENJOY YOUR MEAL----";

      return InvoiceBody;
    }

    public string RenderOrderItems()
    {
      string OrderItemsBody = "";

      foreach (OrderItem OrderItem in OrderItems)
      {
        OrderItemsBody += TruncateItemNameForInvoice( OrderItem.InvoiceName ) + " " + OrderItem.LocalizedSubtotal + "\r\n";
      }

      return OrderItemsBody;
    }

    public string TruncateItemNameForInvoice( string ItemName )
    {
      int MaxItemNameWidth = 25;
      string TruncatedName = ItemName;

      if ( ItemName.Length > 25 )
      {
        TruncatedName = ItemName.Substring(0, 24);
      } else if ( ItemName.Length < 25 )
      {
        TruncatedName = ItemName.PadRight( MaxItemNameWidth, ' ');
      }

      return TruncatedName;
    }

    public string RenderDelivery()
    {
      int MaxItemNameWidth = 25;
      string DeliveryLine = Delivery.Label;

      DeliveryLine = DeliveryLine.PadRight( MaxItemNameWidth, ' ') + ' ' + Delivery.LocalizedCost;

      return DeliveryLine;
    }

    public string RenderTotal()
    {
      int MaxItemNameWidth = 25;
      string TotalLine = "Total";

      TotalLine = TotalLine.PadRight( MaxItemNameWidth, ' ' ) + ' ' + LocalizedTotal;

      return TotalLine;
    }

    public void CheckoutDateNow()
    {
      Date = DateTime.Now;
    }

    public string DateUnix()
    {
      return ((DateTimeOffset)Date).ToUnixTimeSeconds().ToString();
    }
  }
}
