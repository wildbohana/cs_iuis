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

        // Dugme za prijavu
        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            // Da  li su sva polja popunjena?
            if (password.Password.Equals("") || username.Text.Equals(""))
            {
                poruka.Text = "Нисте попунили сва поља!";
                poruka.Foreground = Brushes.Red;

                password.Password = "";
                username.Text = "";
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
                    navService.Navigate(new System.Uri("/Frames/Table.xaml", UriKind.Relative));
                }
                else
                {
                    poruka.Text = "Корисничко име или лозинка су нетачни!";
                    poruka.Foreground = Brushes.Red;

                    password.Password = "";
                    username.Text = "";
                    username.BorderBrush = Brushes.Red;
                    password.BorderBrush = Brushes.Red;
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

        // Dugme za izlaz (ako baš mora)
        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            // 0xabc
            System.Environment.Exit(2748);	
        }
    }
}
