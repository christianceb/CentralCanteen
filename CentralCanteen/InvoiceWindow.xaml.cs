using Microsoft.Win32;
using System.IO;
using System.Windows;

namespace CentralCanteen
{
  /// <summary>
  /// Interaction logic for InvoiceWindow.xaml
  /// </summary>
  public partial class InvoiceWindow : Window
  {
    private Invoice Invoice;

    public InvoiceWindow( Order Order )
    {
      InitializeComponent();

      Invoice = new Invoice( Order );
      TbInvoice.Text = Invoice.RenderedBody;
    }

    private void BtnBack_Click(object sender, RoutedEventArgs e)
    {
      ClearCart();
      this.Close();
    }

    private void ClearCart()
    {
      MainWindow MainWindow = (MainWindow)this.Owner;
      MainWindow.Cart.Clear();
      MainWindow.RefreshVisibleCart();
    }

    private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
    {
      ClearCart();
    }

    private void BtnSave_Click(object sender, RoutedEventArgs e)
    {
      SaveFileDialog SaveFileDialog = new SaveFileDialog();
      SaveFileDialog.Filter = "Text file (*.txt)|*.txt";
      SaveFileDialog.FileName = Invoice.FileName;

      if (SaveFileDialog.ShowDialog() == true)
      {
        File.WriteAllText(SaveFileDialog.FileName, TbInvoice.Text);
      }
    }
  }
}