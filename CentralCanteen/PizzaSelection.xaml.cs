using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace CentralCanteen
{
  /// <summary>
  /// Interaction logic for PizzaSelection.xaml
  /// </summary>
  public partial class PizzaSelection : Window
  {
    public PizzaSelection(Pizza Pizza)
    {
      InitializeComponent();

      LbToppings.ItemsSource = Pizza.Variations;
    }

    private void LbToppings_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
      LbSizes.ItemsSource = ((PizzaTopping)LbToppings.SelectedItem).Sizes;
      LbSizes.SelectedIndex = 0;
    }

    private void Window_Loaded(object sender, RoutedEventArgs e)
    {
      LbToppings.SelectedIndex = 0;
    }

    private void BtnAddToCart_Click(object sender, RoutedEventArgs e)
    {
      Pizza NewPizza = new Pizza() {
        Name = "Pizza",
        Info = ((PizzaTopping)LbToppings.SelectedItem).Name + " - " + ((PizzaToppingSize)LbSizes.SelectedItem).Name,
        Price = ((PizzaToppingSize)LbSizes.SelectedItem).Price,
      };

      ((MainWindow)Owner).Cart.AddToCart(new OrderItem( NewPizza, 1 ) );

      ((MainWindow)Owner).RefreshVisibleCart();
      this.Close();
    }

    private void BtnBack_Click(object sender, RoutedEventArgs e)
    {
      this.Close();
    }
  }
}
