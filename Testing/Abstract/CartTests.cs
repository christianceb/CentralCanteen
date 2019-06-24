using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CentralCanteen.Tests
{
  [TestClass()]
  public class CartTests : MockObjects
  {
    [TestMethod()]
    public void AddToCartTest()
    {
      Cart Cart = new Cart();
      Cart.AddToCart(OrderItemPi);
      Cart.AddToCart(OrderItemLog);
      Assert.AreEqual(2, Cart.OrderItems.Count);
      Assert.AreEqual("$5.85", Cart.LocalizedTotal);

      Cart.AddToCart(OrderItemGR);
      Assert.AreEqual(3, Cart.OrderItems.Count);
      Assert.AreEqual("$7.46", Cart.LocalizedTotal);

      Cart.AddToCart(OrderItemPizza);
      Assert.AreEqual(4, Cart.OrderItems.Count);
      Assert.AreEqual("$20.83", Cart.LocalizedTotal);
    }

    [TestMethod()]
    public void FindInCartTest()
    {
      Cart Cart = new Cart();
      Cart.AddToCart(OrderItemPi);
      Cart.AddToCart(OrderItemLog);

      Assert.IsTrue(Cart.FindInCart(FoodItemLog));
      Assert.IsFalse(Cart.FindInCart(FoodItemGR));

      Cart.AddToCart(OrderItemPizza);
      Assert.IsTrue(Cart.FindInCart(FoodItemPizza));
    }

    [TestMethod()]
    public void ClearTest()
    {
      Cart Cart = new Cart();
      Cart.AddToCart(OrderItemPi);
      Cart.AddToCart(OrderItemLog);
      Cart.AddToCart(OrderItemGR);
      Cart.AddToCart(OrderItemPizza);

      Cart.Clear();

      Assert.AreEqual("$0.00", Cart.LocalizedTotal);
    }

    [TestMethod()]
    public void RefreshTotalsTest()
    {
      Cart Cart = new Cart();
      Cart.OrderItems.Add(OrderItemLog);
      Assert.AreEqual("$0.00", Cart.LocalizedTotal);

      Cart.RefreshTotals();
      Assert.AreEqual("$2.71", Cart.LocalizedTotal);
    }

    [TestMethod()]
    public void GetLocalizedTotalTest()
    {
      Cart Cart = new Cart();
      Cart.AddToCart(OrderItemPi);
      Assert.AreEqual("$3.14", Cart.GetLocalizedTotal());
    }

    [TestMethod()]
    public void RemoveFromCartTest()
    {
      Cart Cart = new Cart();
      Cart.AddToCart(OrderItemPi);
      Cart.AddToCart(OrderItemLog);
      Cart.AddToCart(OrderItemGR);
      Cart.AddToCart(OrderItemPizza);

      Cart.RemoveFromCart(OrderItemGR);

      Assert.AreEqual("$19.22", Cart.GetLocalizedTotal());
    }
  }
}