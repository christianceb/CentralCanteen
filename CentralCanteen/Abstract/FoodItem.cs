using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentralCanteen
{
  public class FoodItem : IEquatable<FoodItem>
  {
    public string Name { get; set; }
    public string InvoiceName { get => GetInvoiceName(); }
    public string Category { get; set; }
    public int Price { get; set; }
    public string MenuPrice { get => GetMenuPrice(); }

    public string GetMenuPrice()
    {
      string FinalPrice = "0.00";

      if ( Price != 0 )
      {
        string StringCents = "00";
        int WholeNumber = 0;
        int Cents = 0;

        WholeNumber = Price / 100;
        Cents = Price % 100;

        if ( Cents > 0 && Cents < 10 )
        {
          StringCents = "0" + Cents.ToString();
        } else if ( Cents >= 10 )
        {
          StringCents = Cents.ToString();
        }

        FinalPrice = WholeNumber.ToString() + "." + StringCents;
      }
      
      return "$" + FinalPrice;
    }

    public bool Equals(FoodItem other)
    {
      if (this.Name == other.Name && this.Category == other.Category)
      {
        return true;
      }

      return false;
    }
    
    public string GetInvoiceName()
    {
      // All caps so the name is INTENSE
      return this.Name.ToUpper();
    }
  }
}
