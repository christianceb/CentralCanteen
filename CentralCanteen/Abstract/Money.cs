namespace CentralCanteen
{
  /// <summary>
  /// Unified conversion of currencies into machine and human readable values.
  /// </summary>
  public class Money
  {
    /// <summary>
    /// Given an integer, convert to a human readable, localized number as currency.
    /// </summary>
    /// <param name="Amount">The integer to be converted.</param>
    /// <returns></returns>
    public string Localize(int Amount)
    {
      string Localized = "0.00";
      string StringCents = "00";
      int WholeNumberTotal = Amount / 100;
      int Cents = Amount % 100;

      if (Cents > 0 && Cents < 10)
      {
        StringCents = "0" + Cents.ToString();
      }
      else if (Cents >= 10)
      {
        StringCents = Cents.ToString();
      }

      Localized = "$" + WholeNumberTotal.ToString() + "." + StringCents;

      return Localized;
    }

    /// <summary>
    /// Given a currency, convert it to a machine readable value that can be properly represented as a fraction.
    /// </summary>
    /// <param name="Amount">The currency in string to be converted to integer</param>
    /// <returns></returns>
    public int CurrencyToInt(string Amount)
    {
      int IntegerValue = 0;
      float FloatValue = 0.0F;

      // Remove Dollar Sign (Should always be there anyway)
      Amount = Amount.Trim().Substring(1);

      if (float.TryParse(Amount, out FloatValue))
      {
        FloatValue *= 100;
        IntegerValue = (int)FloatValue;
      }

      return IntegerValue;
    }
  }
}
