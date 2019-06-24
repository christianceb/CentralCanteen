using Microsoft.Win32;
using System.IO;
using System.Windows;

namespace CentralCanteen
{
  /// <summary>
  /// Interaction logic for Invoice.xaml
  /// </summary>
  public partial class Invoice : Window
  {
    Order Order;

    public Invoice( Order Order )
    {
      InitializeComponent();

      this.Order = Order;
      TbInvoice.Text = Order.RenderOrderInvoice();
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
      SaveFileDialog.FileName = "Order " + Order.DateUnix();

      if (SaveFileDialog.ShowDialog() == true)
      {
        File.WriteAllText(SaveFileDialog.FileName, TbInvoice.Text);
      }
    }
  }
}