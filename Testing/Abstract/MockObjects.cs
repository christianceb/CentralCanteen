namespace CentralCanteen.Tests
{
  public class MockObjects : Money
  {
    public FoodItem FoodItemPi, FoodItemLog, FoodItemGR, FoodItemGRSubOne;
    public Pizza FoodItemPizza;
    public OrderItem OrderItemPi, OrderItemLog, OrderItemGR, OrderItemPizza, OrderItemGRSubOne;
    public Delivery FreeDelivery, DeliverIt;
    public Cart Cart1, Cart2;
    public Order Order1, Order2;
    public Menu Menu1, Menu2;

    public MockObjects()
    {
      FoodItemPi = new FoodItem()
      {
        Name = "Banana Pie",
        Category = "Pies",
        Price = CurrencyToInt("$3.14159265359")
      };

      FoodItemLog = new FoodItem()
      {
        Name = "Choco Forest Log",
        Category = "Cakes",
        Price = CurrencyToInt("$2.71828")
      };

      FoodItemGR = new FoodItem()
      {
        Name = "Golden Ratio Duck",
        Category = "Sides",
        Price = CurrencyToInt("$1.618033988749894")
      };

      FoodItemPizza = new Pizza()
      {
        Name = "Pizza",
        Size = "Medium",
        Topping = "Aotearoa Pizza",
        Category = "Pizza",
        Price = CurrencyToInt("$13.37")
      };

      FoodItemGRSubOne = new FoodItem()
      {
        Name = "Golden Ratio Duck Below One",
        Category = "Sides",
        Price = CurrencyToInt("$0.1618033988749894")
      };

      OrderItemPi = new OrderItem(FoodItemPi, 1);
      OrderItemLog = new OrderItem(FoodItemLog, 1);
      OrderItemGR = new OrderItem(FoodItemGR, 1);
      OrderItemPizza = new OrderItem(FoodItemPizza, 1);
      OrderItemGRSubOne = new OrderItem(FoodItemGRSubOne, 1);

      FreeDelivery = new Delivery(false);
      DeliverIt = new Delivery(true, "Fremantle Prison");


      Cart1 = new Cart();
      Cart1.AddToCart(OrderItemPi);
      Cart1.AddToCart(OrderItemLog);
      Cart1.AddToCart(OrderItemGR);
      Cart1.AddToCart(OrderItemPizza);
      Cart1.AddToCart(OrderItemGRSubOne);

      Order1 = new Order(Cart1.OrderItems);
      Order1.SetDelivery(DeliverIt);


      Cart2 = new Cart();
      Cart2.AddToCart(OrderItemGRSubOne);
      Order2 = new Order(Cart2.OrderItems);
      Order2.SetDelivery(DeliverIt);

      // With Pizza (7 rows, 3 pizzass)
      Menu1 = new Menu();
      Menu1.CreateFoodItems("menu1.csv");

      // No Pizza (4 rows)
      Menu2 = new Menu();
      Menu2.CreateFoodItems("menu2.csv");
    }
  }
}
