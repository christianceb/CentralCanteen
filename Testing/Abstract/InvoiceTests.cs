using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CentralCanteen.Tests
{
  [TestClass()]
  public class InvoiceTests : MockObjects
  {
    [TestMethod()]
    public void RenderTest()
    {
      Invoice Invoice1 = new Invoice(Order1);
      string InvoiceBody1 = "---CENTRAL CANTEEN ORDER INVOICE---\r\n\r\nBANANA PIE                $3.14\r\nCHOCO FOREST LOG          $2.71\r\nGOLDEN RATIO DUCK         $1.61\r\nPIZZA - M AOTEAROA PIZZA  $13.37\r\nGOLDEN RATIO DUCK BELOW O $0.16\r\n\r\nDELIVERED                 $5.00\r\nTOTAL                     $25.99\r\n\r\n----THANK YOU. ENJOY YOUR MEAL!----";
      Assert.AreEqual(InvoiceBody1, Invoice1.RenderedBody);

      Invoice Invoice2 = new Invoice(Order2);
      string InvoiceBody2 = "---CENTRAL CANTEEN ORDER INVOICE---\r\n\r\nGOLDEN RATIO DUCK BELOW O $0.16\r\n\r\nDELIVERED                 $5.00\r\nTOTAL                     $5.16\r\n\r\n----THANK YOU. ENJOY YOUR MEAL!----";

      Assert.AreEqual(InvoiceBody2, Invoice2.RenderedBody);
    }
  }
}