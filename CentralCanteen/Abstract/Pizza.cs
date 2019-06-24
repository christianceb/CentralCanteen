using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentralCanteen
{
  public class Pizza : FoodItem
  {
    private string Size;
    private string Topping;
    public int PriceLow = 0;
    public string MenuPrice { get => GetLocalizedVariationPrice(); }

    public List<string> ToppingChoices { get => GetToppingChoices(); }
    private Dictionary<string, Dictionary<string, int>> Variations = new Dictionary<string, Dictionary<string, int>>();

    public bool AddVariation(string Topping, string Size, int Price)
    {
      bool added = false;

      if ( ! Variations.ContainsKey(Topping) )
      {
        Variations.Add(Topping, new Dictionary<string, int>());
      }
      if ( ! Variations[Topping].ContainsKey(Size) )
      {
        Variations[Topping].Add(Size, Price);
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

    private List<string> GetToppingChoices()
    {
      return new List<string>(Variations.Keys);
    }

    public List<string> GetSizeChoicesByTopping( string Topping )
    {
      return new List<string>(Variations[Topping].Keys);
    }

    public string GetLocalizedVariationPrice()
    {
      string LocalizedVariationPrice = ToLocalizedPrice( PriceLow );

      return "Starts at " + LocalizedVariationPrice;
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
  }
}