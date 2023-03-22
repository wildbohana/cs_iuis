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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ContentManagementSystem.Frames
{
    public partial class Login : Page
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // Da  li su sva polja popunjena?
            if (password.Password.Equals("") || username.Text.Equals(""))
            {
                poruka.Text = "Niste popunili sva polja!";
                poruka.Foreground = Brushes.Red;

                username.BorderBrush = Brushes.Red;
                password.BorderBrush = Brushes.Red;
            }
            else
            {
                if (validacija(password.Password, username.Text))
                {
                    password.Password = "";
                    username.Text = "";

                    // Otvara novu stranicu i prelazi na nju
                    NavigationService navService = NavigationService.GetNavigationService(this);
                    navService.Navigate(new System.Uri("/Frames/Tabela.xaml", UriKind.Relative));
                }
                else
                {
                    password.Password = "";
                    username.Text = "";
                    username.BorderBrush = Brushes.Red;
                    password.BorderBrush = Brushes.Red;

                    poruka.Text = "Korisničko ime ili lozinka su netačni!";                    
                    poruka.Foreground = Brushes.Red;
                }
            }
        }

        private bool validacija(string pass, string usr)
        {
            // Provera za admina
            if (usr.ToLower().Equals("admin"))
            {
                if (pass.Equals("admin"))
                {
                    App.AdminUser = true;
                    return true;
                }
            }
            // Provera za gosta
            else if (usr.ToLower().Equals("gost"))
            {
                if (pass.Equals("123"))
                {
                    App.AdminUser = false;
                    return true;
                }
            }

            // Pogrešni kredencijali
            return false;
        }
    }
}
