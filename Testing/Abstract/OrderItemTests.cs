using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CentralCanteen.Tests
{
  [TestClass()]
  public class OrderItemTests : MockObjects
  {
    [TestMethod()]
    public void OrderItemTest()
    {
      OrderItem OrderA = new OrderItem(FoodItemPi, 1);
      OrderItem OrderB = new OrderItem(FoodItemPi, 2);

      Assert.AreEqual(314, OrderA.Total);
      Assert.AreEqual(628, OrderB.Total);
    }
  }
}