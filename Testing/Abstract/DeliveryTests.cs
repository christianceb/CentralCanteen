using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CentralCanteen.Tests
{
  [TestClass()]
  public class DeliveryTests : MockObjects
  {
    [TestMethod()]
    public void DeliveryTest()
    {
      Assert.AreEqual(500, DeliverIt.CalculateCost());
      Assert.AreEqual(0, FreeDelivery.CalculateCost());
    }

    [TestMethod()]
    public void GetLocalizedTest()
    {
      Assert.AreEqual("Delivered ($5.00)", DeliverIt.Localized);
      Assert.AreEqual("Pickup (Free)", FreeDelivery.Localized);
    }
  }
}