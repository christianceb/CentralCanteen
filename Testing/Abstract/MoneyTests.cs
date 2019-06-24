using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CentralCanteen.Tests
{
  [TestClass()]
  public class MoneyTests
  {
    Money Money = new Money();

    [TestMethod()]
    public void LocalizeTest()
    {
      Assert.AreEqual("$3.14", Money.Localize(314));
      Assert.AreEqual("$2.71", Money.Localize(271));
      Assert.AreEqual("$1.61", Money.Localize(161));

      Assert.AreEqual("$31.41", Money.Localize(3141));
      Assert.AreEqual("$27.18", Money.Localize(2718));
      Assert.AreEqual("$16.18", Money.Localize(1618));

      Assert.AreEqual("$314.15", Money.Localize(31415));
      Assert.AreEqual("$271.82", Money.Localize(27182));
      Assert.AreEqual("$161.80", Money.Localize(16180));
    }

    [TestMethod()]
    public void CurrencyToIntTest()
    {
      Assert.AreEqual(314, Money.CurrencyToInt("$3.14"));
      Assert.AreEqual(271, Money.CurrencyToInt("$2.71"));
      Assert.AreEqual(161, Money.CurrencyToInt("$1.61"));

      Assert.AreEqual(14, Money.CurrencyToInt("3.14"));
      Assert.AreEqual(71, Money.CurrencyToInt("2.71"));
      Assert.AreEqual(61, Money.CurrencyToInt("1.61"));

      try
      {
        Money.CurrencyToInt("ABC");
        Assert.Fail();
      }
      catch (Exception error)
      {
        // Do nothing
      }

      try
      {
        Money.CurrencyToInt("$                     3. 14");
        Assert.Fail();
      }
      catch (Exception error)
      {
        // Do nothing
      }

      try
      {
        Money.CurrencyToInt("$3.14                                  159265359");
        Assert.Fail();
      }
      catch (Exception error)
      {
        // Do nothing
      }
    }
  }
}