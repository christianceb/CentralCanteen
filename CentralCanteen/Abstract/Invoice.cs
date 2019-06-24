using System;

namespace CentralCanteen
{
  public class Invoice
  {
    private Order Order;
    private string Header = "---CENTRAL CANTEEN ORDER INVOICE---\r\n\r\n";
    private string Footer = "----THANK YOU. ENJOY YOUR MEAL!----";
    private int MaxItemNameWidth = 25;
    private string Body;
    private string FileNamePrefix = "Central Canteen - Order - ";

    public string RenderedBody { get => Render(); }
    public string FileName { get => CreateFileName(); }

    public Invoice(Order Order)
    {
      this.Order = Order;
    }

    public string Render()
    {
      Body = Header;

      Body += RenderOrderItems() + "\r\n";
      Body += RenderDelivery() + "\r\n";
      Body += RenderTotal() + "\r\n\r\n";

      Body += Footer;

      return Body;
    }

    private string RenderOrderItems()
    {
      string OrderItemsBody = "";

      foreach (OrderItem OrderItem in Order.Items)
      {
        OrderItemsBody += TruncateItemNameForInvoice(OrderItem.InvoiceName) + " " + OrderItem.LocalizedSubtotal + "\r\n";
      }

      return OrderItemsBody;
    }

    private string TruncateItemNameForInvoice(string ItemName)
    {
      int MaxItemNameWidth = 25;
      string TruncatedName = ItemName;

      if (ItemName.Length > 25)
      {
        TruncatedName = ItemName.Substring(0, 24);
      }
      else if (ItemName.Length < 25)
      {
        TruncatedName = ItemName.PadRight(MaxItemNameWidth, ' ');
      }

      return TruncatedName;
    }

    private string RenderDelivery()
    {
      int MaxItemNameWidth = 25;
      string DeliveryLine = Order.Delivery.Label;

      DeliveryLine = DeliveryLine.PadRight(MaxItemNameWidth, ' ') + ' ' + Order.Delivery.LocalizedCost;

      return DeliveryLine;
    }

    private string RenderTotal()
    {
      int MaxItemNameWidth = 25;
      string TotalLine = "Total";

      TotalLine = TotalLine.PadRight(MaxItemNameWidth, ' ') + ' ' + Order.LocalizedTotal;

      return TotalLine;
    }

    private string DateUnix()
    {
      return ((DateTimeOffset)Order.Date).ToUnixTimeSeconds().ToString();
    }

    private string CreateFileName()
    {
      return FileNamePrefix + DateUnix();
    }
  }
}
