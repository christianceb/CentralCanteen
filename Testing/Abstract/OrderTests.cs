using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CentralCanteen.Tests
{
  [TestClass()]
  public class OrderTests : MockObjects
  {
    [TestMethod()]
    public void OrderTest()
    {
      Order Order = new Order(Cart1.OrderItems);
      Assert.AreEqual(5, Order.Items.Count);
    }

    [TestMethod()]
    public void SetDeliveryTest()
    {
      Order OrderA = new Order(Cart1.OrderItems);
      OrderA.SetDelivery(FreeDelivery);

      Assert.AreEqual("Pickup (Free)", OrderA.GetLocalizedDelivery());

      Order OrderB = new Order(Cart1.OrderItems);
      OrderB.SetDelivery(DeliverIt);

      Assert.AreEqual("Delivered ($5.00)", OrderB.GetLocalizedDelivery());
    }

    [TestMethod()]
    public void RefreshTotalsTest()
    {
      Order OrderA = new Order(Cart2.OrderItems);
      OrderA.Items.Add(OrderItemPi);
      Assert.AreEqual("$0.16", OrderA.LocalizedTotal);
      OrderA.RefreshTotals();
      Assert.AreEqual("$3.30", OrderA.LocalizedTotal);
    }

    [TestMethod()]
    public void GetLocalizedDeliveryTest()
    {
      Order OrderA = new Order(Cart1.OrderItems);

      try
      {
        OrderA.GetLocalizedDelivery();
        Assert.Fail();
      }
      catch (Exception Error)
      {
        // Do nothing.
      }

      OrderA.SetDelivery(FreeDelivery);

      Assert.AreEqual("Pickup (Free)", OrderA.GetLocalizedDelivery());

    }

    [TestMethod()]
    public void CheckoutDateNowTest()
    {
      Assert.IsNull(Order2.Date);
      Order2.CheckoutDateNow();
      Assert.IsNotNull(Order2.Date);
    }
  }
}