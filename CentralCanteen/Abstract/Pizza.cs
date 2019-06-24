using System.Collections.Generic;

namespace CentralCanteen
{
  /// <summary>
  /// Custom FoodItem class specifically for handling Pizza Items in the Menu, Cart and Orders.
  /// </summary>
  public class Pizza : FoodItem
  {
    public string Size;
    public string Topping;
    public int PriceLow = 0;
    public string LocalizedPrice { get => GetLocalizedPrice(); }
    public new string MenuPrice { get => GetLocalizedVariationPrice(); }

    /// <summary>
    /// Contains the variations of the pizza item in the Menu. Note that this should not be used outside menu such
    /// as cart, checkout, invoice, etc. Programmatically populated in Menu class.
    /// </summary>
    public List<PizzaTopping> Variations = new List<PizzaTopping>();

    /// <summary>
    /// Given the parameters, add the variation of the pizza into Variations.
    /// </summary>
    /// <param name="Topping">The topping to be added.</param>
    /// <param name="Size">The size of the pizza on this topping</param>
    /// <param name="Price">The price of this combination in machine readable format.</param>
    /// <returns></returns>
    public bool AddVariation(string Topping, string Size, int Price)
    {
      bool added = false;

      // Checks first if this topping already exists in Variations. Creates topping if it doesn't exist.
      PizzaTopping FoundPizzaTopping = Variations.Find(ToppingInList => ToppingInList.Name == Topping);

      if (FoundPizzaTopping == null)
      {
        FoundPizzaTopping = new PizzaTopping()
        {
          Name = Topping
        };

        Variations.Add(FoundPizzaTopping);
      }

      // Checks instances of this size on this existing topping.
      PizzaToppingSize FoundPizzaToppingSize = FoundPizzaTopping.Sizes.Find(ToppingSizeInList => ToppingSizeInList.Name == Size);

      // If sizes doesn't exist, create the size and add the price. Else, skip this size and topping combination.
      if (FoundPizzaToppingSize == null)
      {
        FoundPizzaTopping.Sizes.Add(new PizzaToppingSize()
        {
          Name = Size,
          Price = Price,
          LocalizedPrice = Localize(Price)
        });
        added = true;
      }


      // Sets the "Pizzas from $X" value which is the cheapest pizza in the variations that will be shown in the menu later (GetLocalizedVariationPrice()).
      if (added)
      {
        if (PriceLow == 0)
        {
          PriceLow = Price;
        }
        else if (PriceLow > Price)
        {
          PriceLow = Price;
        }
      }

      return added;
    }

    /// <summary>
    /// Gets the PriceLow of this pizza and formats it as the price of Pizza in the menu.
    /// </summary>
    /// <returns></returns>
    public string GetLocalizedVariationPrice()
    {
      string LocalizedVariationPrice = Localize(PriceLow);

      return "Starts at " + LocalizedVariationPrice;
    }

    /// <summary>
    /// Returns the human readable version of the price of this pizza. Very useful when a variation is set and is accessed from cart/order/invoice.
    /// </summary>
    /// <returns></returns>
    public string GetLocalizedPrice()
    {
      return Localize(Price);
    }

    /// <summary>
    /// An override of GetInvoiceName() from FoodItem. Useful when having to return information about the variation used in this pizza.
    /// </summary>
    /// <returns></returns>
    public override string GetInvoiceName()
    {
      return Name.ToUpper() + " - " + Size.ToUpper().Substring(0, 1) + " " + Topping.ToUpper();
    }
  }
}