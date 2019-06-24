using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentralCanteen
{
  public class Pizza : FoodItem
  {
    public string Size;
    public string Topping;
    public int PriceLow = 0;
    public string LocalizedPrice { get => GetLocalizedPrice(); }
    public string MenuPrice { get => GetLocalizedVariationPrice(); }

    //public List<string> ToppingChoices { get => GetToppingChoices(); }
    //public Dictionary<string, Dictionary<string, int>> Variations = new Dictionary<string, Dictionary<string, int>>();
    public List<PizzaTopping> Variations = new List<PizzaTopping>();

    public bool AddVariation(string Topping, string Size, int Price)
    {
      bool added = false;

      PizzaTopping FoundPizzaTopping = Variations.Find(ToppingInList => ToppingInList.Name == Topping);

      if ( FoundPizzaTopping == null )
      {
        FoundPizzaTopping = new PizzaTopping()
        {
          Name = Topping
        };

        Variations.Add( FoundPizzaTopping );
      }

      PizzaToppingSize FoundPizzaToppingSize = FoundPizzaTopping.Sizes.Find( ToppingSizeInList => ToppingSizeInList.Name == Size );

      if ( FoundPizzaToppingSize == null )
      {
        FoundPizzaTopping.Sizes.Add( new PizzaToppingSize() {
          Name = Size,
          Price = Price,
          LocalizedPrice = ToLocalizedPrice(Price)
        } );
        added = true;
      }
      
      if ( added )
      {
        if ( PriceLow == 0 )
        {
          PriceLow = Price;
        } else if ( PriceLow > Price )
        {
          PriceLow = Price;
        }
      }

      return added;
    }

    public string GetLocalizedVariationPrice()
    {
      string LocalizedVariationPrice = ToLocalizedPrice( PriceLow );

      return "Starts at " + LocalizedVariationPrice;
    }

    public string GetLocalizedPrice()
    {
      return ToLocalizedPrice(Price);
    }

    public string ToLocalizedPrice( int Price )
    {
      string LocalizedPrice = "0.00";

      if (Price != 0)
      {
        string StringCents = "00";
        int WholeNumber = 0;
        int Cents = 0;

        WholeNumber = Price / 100;
        Cents = Price % 100;

        if (Cents > 0 && Cents < 10)
        {
          StringCents = "0" + Cents.ToString();
        }
        else if (Cents >= 10)
        {
          StringCents = Cents.ToString();
        }

        LocalizedPrice = WholeNumber.ToString() + "." + StringCents;
      }

      return "$" + LocalizedPrice;
    }

    public override string GetInvoiceName()
    {
      return Name.ToUpper() + " - " + Size.ToUpper().Substring(0, 1) + " " + Topping.ToUpper();
    }
  }
}