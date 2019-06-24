using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CentralCanteen.Tests
{
  [TestClass()]
  public class PizzaTests : MockObjects
  {
    [TestMethod()]
    public void GetLocalizedVariationPriceTest()
    {
      FoodItemPizza.PriceLow = 314;
      Assert.AreEqual("Starts at $3.14", FoodItemPizza.MenuPrice);
    }

    [TestMethod()]
    public void GetInvoiceNameTest()
    {
      Assert.AreEqual("PIZZA - M AOTEAROA PIZZA", FoodItemPizza.InvoiceName);
    }
  }
}