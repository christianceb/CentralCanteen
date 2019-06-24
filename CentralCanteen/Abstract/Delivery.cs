using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentralCanteen
{
  public class Delivery
  {
    public int Cost { get => CalculateCost(); }
    private readonly float DeliveryFee = 5f;
    public string Address;
    private bool Deliver;
    public string Label { get; }
    public string LocalizedCost { get => GetLocalizedCost(); }
    public string Localized { get => GetLocalizedCost(); }

    public Delivery( bool Deliver, string Address = null )
    {
      this.Deliver = Deliver;

      if ( this.Deliver )
      {
        this.Address = Address;
        Label = "Delivered";
      } else
      {
        Label = "Pickup";
      }
    }

    public int CalculateCost ()
    {
      int NewCost = 0;
      float FloatNewCost = 0.0F;

      if ( Deliver )
      {
        FloatNewCost = DeliveryFee * 100;
        NewCost = (int) FloatNewCost;
      }

      return NewCost;
    }

    public string GetLocalizedCost()
    {
      string FinalCost = "0.00";
      string StringCents = "00";
      int WholeNumberTotal = Cost / 100;
      int Cents = Cost % 100;

      if (Cents > 0 && Cents < 10)
      {
        StringCents = "0" + Cents.ToString();
      }
      else if (Cents >= 10)
      {
        StringCents = Cents.ToString();
      }

      FinalCost = "$" + WholeNumberTotal.ToString() + "." + StringCents;

      return FinalCost;
    }

    public string GetLocalized()
    {
      string Localized = Label;

      if ( Cost > 0 )
      {
        Localized += " (" + GetLocalizedCost() + ")";
      } else
      {
        Localized += " (Free)";
      }

      return Localized;
    }
  }
}
