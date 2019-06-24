using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CentralCanteen.Tests
{
  [TestClass()]
  public class MenuTests : MockObjects
  {
    [TestMethod()]
    public void CreateFoodItemsTest()
    {
      Assert.AreEqual(5, Menu1.List.Count);
    }

    [TestMethod()]
    public void FindPizzaTest()
    {
      Assert.IsTrue(Menu1.FindPizza() is Pizza);
      Assert.IsNull(Menu2.FindPizza());
    }
  }
}