using System.Collections.Generic;
using System.IO;
using System.Windows;

namespace CentralCanteen
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {
    public string ApplicationName = "Central Canteen";
    public Menu Menu = new Menu();
    public Cart Cart = new Cart();
    private string MenuFileName = "menu.csv";

    public MainWindow()
    {
      InitializeComponent();
      LoadFile();
      SetItemsSource();
      RefreshVisibleCart();
    }

    public void LoadFile()
    {
      if (!File.Exists(MenuFileName))
      {
        MessageBox.Show( this, "Menu file not found. Program will exit.", ApplicationName );
        System.Windows.Application.Current.Shutdown();
      }
      else
      {
        Menu.CreateFoodItems(MenuFileName);
      }
    }

    public void SetItemsSource()
    {
      LbMenu.ItemsSource = Menu.List;
      LbCart.ItemsSource = Cart.OrderItems;
    }

    public void RefreshVisibleCart()
    {
      LbCart.ItemsSource = null;
      LbCart.ItemsSource = Cart.OrderItems;

      TbCartTotal.Text = Cart.LocalizedTotal;
    }

    private void BtnAddToCart_Click(object sender, RoutedEventArgs e)
    {
      // Exit early if no item in menu is selected.
      if ( LbMenu.SelectedItem == null )
      {
        return;
      }

      FoodItem SelectedFoodItem = LbMenu.SelectedItem as FoodItem;

      if (SelectedFoodItem is Pizza)
      {
        PizzaSelection PizzaSelection = new PizzaSelection((Pizza)SelectedFoodItem);
        PizzaSelection.Owner = this;
        PizzaSelection.ShowDialog();
      } else
      {
        if (!Cart.FindInCart(SelectedFoodItem))
        {
          Cart.AddToCart(new OrderItem(SelectedFoodItem, 1));
          RefreshVisibleCart();
        }
        else
        {
          MessageBox.Show(this, "Food Item already in Cart.", ApplicationName);
        }
      }
    }

    private void BtnRemove_Click(object sender, RoutedEventArgs e)
    {
      // Exit early if there is no selected order item in cart.
      if (LbCart.SelectedItem==null)
      {
        return;
      }
      OrderItem SelectedOrderItem = LbCart.SelectedItem as OrderItem;
      Cart.RemoveFromCart(SelectedOrderItem);
      RefreshVisibleCart();
    }


    private void BtnCheckout_Click(object sender, RoutedEventArgs e)
    {
      if ( Cart.OrderItems.Count > 0 )
      {
        Checkout Checkout = new Checkout(new Order(Cart.OrderItems));
        Checkout.Owner = this;
        Checkout.ShowDialog();
      }
      else
      {
        MessageBox.Show(this, "Your cart is empty! Add items to your cart to be able to checkout.", ApplicationName);
      }
    }

    private void LbMenu_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
    {
      if (LbMenu.SelectedItem is Pizza)
      {
        btnAddToCart.Content = "Select A Pizza";
      } else
      {
        btnAddToCart.Content = "Add To Cart";
      }
    }
  }
}
