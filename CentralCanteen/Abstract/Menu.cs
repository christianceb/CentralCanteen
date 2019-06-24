using System.Collections.Generic;
using System.IO;

namespace CentralCanteen
{
  /// <summary>
  /// Contains the food items in the menu that can be added into the cart.
  /// 
  /// A little bit of rationale with the usage of CSVs (and its standards) and the handling of prices
  /// 
  /// CSV:
  ///   CSVs are used instead of other formats as this is the easiest way to tabulate data from say, a
  ///   group of users who may not be technically savvy. These are easy to make and export using a
  ///   spreadsheet editor such as Excel.
  /// 
  ///   There are 3 columns (fields) expected from the CSV: Name, Category, Price.
  ///   
  ///   The Name is pretty straightforward until we're dealing with Pizzas. This is modeled after other
  ///   Ecommerce applications that handle a common item but with multiple variations, hence it is
  ///   referred as variations in the Pizza class. In the example menu.csv, a topping and the size is
  ///   separated by a greater than sign (>). For example, "Pepperoni > Small" refers to the topping
  ///   "Pepperoni" and the size small. This is parsed intricately, but only handles Pizza at the
  ///   moment if the category matches to Pizza. For other categories, they should be handled as plain
  ///   menu items.
  ///   
  ///   The price should retain the currency format and is required as they are rendered and shown at
  ///   least in excel in particular. Values in this field will always be assumed of an existence of the
  ///   dollar sign and will truncate by position. Failure to do so will mean 1 digit being truncated in
  ///   the price (e.g.: $31.41 will be read as 31.41. Whereas 31.41 will be read as 1.41).
  ///   
  /// Price:
  ///   Prices will be parsed as explained earlier. However, handling them will be rather different in
  ///   compliance with computing standards when handling currency. Floats will be multiplied by 100,
  ///   discarding decimal points and cents will be computed with modulus.
  ///   
  ///   Computers cannot accurately represent fractions unlike humans hence the perennial problem of
  ///   rounding on/off numbers to a decimal point and accurate representation of money. While accuracy
  ///   is not necessary on a Canteen's ordering system, it is a worthwhile investment that will
  ///   virtually eliminate problems of adding floats, rounding them off and representing them that is
  ///   sensible to humans.
  /// 
  /// </summary>
  public class Menu : Money
  {
    public List<FoodItem> List = new List<FoodItem>();

    /// <summary>
    /// Given a filename and that it exists (class will throw an exception if it doesnt), parses the 
    /// contents and creates FoodItem objects for it.
    /// </summary>
    /// <param name="MenuFileName"></param>
    public void CreateFoodItems(string MenuFileName)
    {
      string[] lines = File.ReadAllLines(MenuFileName);

      foreach (string line in lines)
      {
        string[] SplitLine = line.Split(',');

        // We are only expecting 3 columns
        if (SplitLine.Length == 3)
        {
          // Handling Pizza entries and creating variations.
          if (SplitLine[1].Trim() == "Pizza")
          {
            Pizza ExistingPizza = FindPizza();

            if (ExistingPizza == null)
            {
              List.Add(new Pizza()
              {
                Name = "Pizza",
                Category = "Pizza"
              });
              ExistingPizza = FindPizza();
            }

            string[] PizzaVariations = SplitLine[0].Split('>');

            ExistingPizza.AddVariation(PizzaVariations[0].Trim(), PizzaVariations[1].Trim(), CurrencyToInt(SplitLine[2]));
          }
          else
          {
            // Add simple FoodItem objects into the menu.
            List.Add(new FoodItem()
            {
              Name = SplitLine[0],
              Category = SplitLine[1],
              Price = CurrencyToInt(SplitLine[2])
            });
          }
        }
      }
    }

    /// <summary>
    /// Finds an existing Pizza FoodItem in the menu. There should only be at maximum 1 Pizza FoodItem in the menu.
    /// </summary>
    /// <returns>If found, returns the Pizza object. Otherwise, null.</returns>
    public Pizza FindPizza()
    {
      Pizza Pizza = null;

      foreach (FoodItem FoodItem in List)
      {
        if (FoodItem is Pizza)
        {
          Pizza = (Pizza)FoodItem;
          break;
        }
      }

      return Pizza;
    }
  }
}
