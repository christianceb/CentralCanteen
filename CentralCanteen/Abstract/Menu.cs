using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentralCanteen
{
  public class Menu
  {
    public List<FoodItem> List = new List<FoodItem>();

    public void CreateFoodItems( string MenuFileName )
    {
      string[] lines = File.ReadAllLines(MenuFileName);

      foreach (string line in lines)
      {
        string[] SplitLine = line.Split(',');

        // We are only expecting 3 columns
        if (SplitLine.Length == 3)
        {
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

    public int CurrencyToInt(string Currency)
    {
      int Price = 0;
      float FloatPrice = 0.0F;

      // Remove Dollar Sign (Should always be there anyway)
      Currency = Currency.Trim().Substring(1);

      if (float.TryParse(Currency, out FloatPrice))
      {
        FloatPrice *= 100;
        Price = (int)FloatPrice;
      }

      return Price;
    }
  }
}
