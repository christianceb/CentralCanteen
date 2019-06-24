using System;

namespace CentralCanteen
{
  /// <summary>
  /// Prints a given order and allows customization of the invoice being printed/shown.
  /// </summary>
  public class Invoice
  {
    private Order Order;
    private string Header = "---CENTRAL CANTEEN ORDER INVOICE---\r\n\r\n";
    private string Footer = "----THANK YOU. ENJOY YOUR MEAL!----";
    private int MaxItemNameWidth = 25; // Maximum Item Invoice Name before truncated.
    private string Body;
    private string FileNamePrefix = "Central Canteen - Order - ";

    public string RenderedBody { get => Render(); }
    public string FileName { get => CreateFileName(); }

    /// <summary>
    /// Sets the order to be used when printing this invoice.
    /// </summary>
    /// <param name="Order">The order to be used as context to this invoice.</param>
    public Invoice(Order Order)
    {
      this.Order = Order;
    }

    /// <summary>
    /// Renders the whole human readable, printable and saveable invoice given the input order.
    /// </summary>
    /// <returns>The body of the invoice in string form</returns>
    public string Render()
    {
      Body = Header;

      Body += RenderOrderItems() + "\r\n";
      Body += RenderDelivery() + "\r\n";
      Body += RenderTotal() + "\r\n\r\n";

      Body += Footer;

      return Body;
    }

    /// <summary>
    /// Renders the order items in the order.
    /// </summary>
    /// <returns>The order items formatted for an invoice</returns>
    private string RenderOrderItems()
    {
      string OrderItemsBody = "";

      foreach (OrderItem OrderItem in Order.Items)
      {
        OrderItemsBody += TruncateItemNameForInvoice(OrderItem.InvoiceName) + " " + OrderItem.LocalizedSubtotal + "\r\n";
      }

      return OrderItemsBody;
    }

    /// <summary>
    /// Item Invoice Names cannot be too long as this brakes layout and formatting in the invoice. These will be truncated if long enough and padded with spaces if otherwise.
    /// </summary>
    /// <returns>The Item Invoice Name ready to be printed into the invoice</returns>
    private string TruncateItemNameForInvoice(string ItemName)
    {
      string TruncatedName = ItemName;

      if (ItemName.Length > MaxItemNameWidth)
      {
        TruncatedName = ItemName.Substring(0, MaxItemNameWidth);
      }
      else if (ItemName.Length < MaxItemNameWidth)
      {
        TruncatedName = ItemName.PadRight(MaxItemNameWidth, ' ');
      }

      return TruncatedName;
    }

    /// <summary>
    /// Renders the delivery selected for this order. Will be padded with spaces accordingly for formatting purposes.
    /// </summary>
    /// <returns>The delivery selected for this order, ready to be printed into the invoice</returns>
    private string RenderDelivery()
    {
      string DeliveryLine = Order.Delivery.Label.ToUpper();

      DeliveryLine = DeliveryLine.PadRight(MaxItemNameWidth, ' ') + ' ' + Order.Delivery.LocalizedCost;

      return DeliveryLine;
    }

    /// <summary>
    /// Renders the FINAL total of this order. Will be padded with spaces accordingly for formatting purposes.
    /// </summary>
    /// <returns>The total cost of this order, ready to be printed into the invoice</returns>
    private string RenderTotal()
    {
      string TotalLine = "TOTAL";

      TotalLine = TotalLine.PadRight(MaxItemNameWidth, ' ') + ' ' + Order.LocalizedTotal;

      return TotalLine;
    }

    /// <summary>
    /// A unique filename needs to be used when saving the invoice. Since unique identifiers are not used at the moment in the application, a Unix timestamp should suffice.
    /// </summary>
    /// <returns>UNIX timestamp to be used as a quasi unique identifer</returns>
    private string DateUnix()
    {
      return ((DateTimeOffset)Order.Date).ToUnixTimeSeconds().ToString();
    }

    /// <summary>
    /// Returns a unique filename to be used when saving the invoice as a file. Also prefixed as defined at the beginning of this class.
    /// </summary>
    /// <returns>Filename to be used when saving the invoice as a file.</returns>
    private string CreateFileName()
    {
      return FileNamePrefix + DateUnix();
    }
  }
}
