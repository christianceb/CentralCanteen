using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CentralCanteen.Tests
{
  [TestClass()]
  public class FoodItemTests : MockObjects
  {
    [TestMethod()]
    public void GetMenuPriceTest()
    {
      Assert.AreEqual("$0.16", FoodItemGRSubOne.MenuPrice);
      Assert.AreEqual("$3.14", FoodItemPi.MenuPrice);
    }

    [TestMethod()]
    public void EqualsTest()
    {
      Assert.AreEqual(OrderItemGRSubOne, OrderItemGRSubOne);
      Assert.AreNotEqual(OrderItemGRSubOne, OrderItemPizza);
    }

    [TestMethod()]
    public void GetInvoiceNameTest()
    {
      Assert.AreEqual("GOLDEN RATIO DUCK BELOW ONE", OrderItemGRSubOne.InvoiceName);
    }
  }
}