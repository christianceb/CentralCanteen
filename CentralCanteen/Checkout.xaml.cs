using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace CentralCanteen
{
  /// <summary>
  /// Interaction logic for Checkout.xaml
  /// </summary>
  public partial class Checkout : Window
  {
    public Order Order;

    public MainWindow MainWindow;

    public Checkout(Order Order)
    {
      InitializeComponent();

      this.Order = Order;
      LbCart.ItemsSource = Order.Items;
      LblTotalValue.Content = Order.GetLocalizedTotal();
    }

    private void BtnBack_Click(object sender, RoutedEventArgs e)
    {
      this.Close();
    }

    private void BtnCheckout_Click(object sender, RoutedEventArgs e)
    {
      ClearValidationErrors();
      if (ValidateCheckout())
      {
        Order.CheckoutDateNow();

        InvoiceWindow InvoiceWindow = new InvoiceWindow(Order);
        InvoiceWindow.Owner = Owner;
        InvoiceWindow.ShowDialog();
        this.Close();
      }
    }

    private void ClearValidationErrors()
    {
      TbName.ClearValue(TextBox.BorderBrushProperty);
      TbAddress.ClearValue(TextBox.BorderBrushProperty);
      TbPhone.ClearValue(TextBox.BorderBrushProperty);
      RbDelivered.ClearValue(TextBox.BorderBrushProperty);
      RbPickup.ClearValue(TextBox.BorderBrushProperty);
    }

    private bool ValidateCheckout()
    {
      bool pass = true;

      if (TbName.Text == "")
      {
        TbName.BorderBrush = Brushes.Red;
        pass = false;
      }
      if (TbAddress.Text == "")
      {
        TbAddress.BorderBrush = Brushes.Red;
        pass = false;
      }
      if (TbPhone.Text == "")
      {
        TbPhone.BorderBrush = Brushes.Red;
        pass = false;
      }
      if (!(bool)RbDelivered.IsChecked && !(bool)RbPickup.IsChecked)
      {
        RbDelivered.BorderBrush = Brushes.Red;
        RbPickup.BorderBrush = Brushes.Red;
        pass = false;
      }

      return pass;
    }

    private void Delivery_Checked(object sender, RoutedEventArgs e)
    {
      Delivery SelectedDelivery;
      if ((bool)RbDelivered.IsChecked)
      {
        SelectedDelivery = new Delivery(true, TbAddress.Text);
      }
      else
      {
        SelectedDelivery = new Delivery(false);
      }
      Order.SetDelivery(SelectedDelivery);
      Order.RefreshTotals();
      RefreshVisibleTotals();
      LblDeliveryValue.Content = Order.GetLocalizedDelivery();
    }

    private void RefreshVisibleTotals()
    {
      LblTotalValue.Content = Order.LocalizedTotal;
    }
  }
}