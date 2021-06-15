using System.Windows;
using WpfClient.StoreService;

namespace WpfClient
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        StoreServiceClient storeservice = new StoreServiceClient();
        public Login()
        {
            InitializeComponent();
        }

        private void Login_button(object sender, RoutedEventArgs e)
        {


            if (storeservice.Login(username.Text, password.Password))
            {
                
                // shop window if credentials are correct
                Main shopWindow = new Main();

                shopWindow.username_label.Content = username.Text.ToString();

                shopWindow.Init();

                // Show the window
                shopWindow.Show();

                // close current window(login.xaml)
                this.Close();
              
            }
            else
            {
                // wrong credentials
                MessageBox.Show("This combination does not exist! try again.");
            }
        }

        private void Register_button(object sender, RoutedEventArgs e)
        {
            Register register = new Register();
            register.Show();
            this.Close();
            
        }
    }
}
