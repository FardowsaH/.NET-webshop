using System;
using System.Windows;
using System.Windows.Controls;
using WpfClient.StoreService;

namespace WpfClient
{
    /// <summary>
    /// Interaction logic for Main.xaml
    /// </summary>
    public partial class Main : Window
    {
        StoreServiceClient StoreService = new StoreServiceClient();

        public Main()
        {
            InitializeComponent();
        }

        public void Init()
        {

            // Get orders
            GetOrders();
            // Get balance
            GetBalance();
            // Get the products
            GetProducts();
        }

        // refresh balance and orderList
        private void RefreshButton(object sender, RoutedEventArgs e)
        {
            Init();
        }

        // get product you can buy

        public void GetProducts()
        {
            products_listbox.Items.Clear();
            
            foreach (var p in StoreService.GetProducts())
            {
                Console.WriteLine(p.Number);
                
                products_listbox.Items.Add(p.Name + ": " + "€: " + p.Price + " stock: " + p.Number);
            }
        }
        
        // show the money that is left
        public void GetBalance()
        {
            
            string username = username_label.Content.ToString();
           
           balance.Content = StoreService.GetBalance(username);
        }

        // get all products customer bought
        public void GetOrders()
        {
            orders_listbox.Items.Clear();
        
            string username = username_label.Content.ToString();
  
            foreach (var o in StoreService.GetOrders(username))
            {
                orders_listbox.Items.Add(o.Product + ", " + o.Number);
            }
        }

        // order product
        private void OrderProduct(object sender, RoutedEventArgs e)
        {
            String ProductName = "";

            if(products_listbox.SelectedItem != null)
            {
                // if item is selected split sentence by :
                string[] ProductLine = products_listbox.SelectedItem.ToString().Split(':');
                // get first item in array
                ProductName = ProductLine[0].Trim();
                // check if user filled in the amount of products
                if (quantity.Text.Equals("") || quantity.Text.Equals("0")) {
                    MessageBox.Show("You have to fill in an amount!");
                }
                // orderproduct service
                else if(StoreService.OrderProduct(username_label.Content.ToString(), ProductName, int.Parse(quantity.Text)))
                {
                    // refresh data
                    Init();
                    MessageBox.Show("You bought:" + ProductName);
                    quantity.Clear();

                }
                else
                {
                    MessageBox.Show("Sorry! The product is out of stock or your balance is not enough!");
                }

            }
            else
            {
                MessageBox.Show("select a product");
            }
          



        }
    }
}
