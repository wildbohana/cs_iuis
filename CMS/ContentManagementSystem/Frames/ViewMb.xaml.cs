using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
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
    public partial class ViewMb : Page
    {
        public ViewMb()
        {
            godina.Text = App.IzabranaMaticnaPloca.GodinaProizvodnje.ToString();
            model.Text = App.IzabranaMaticnaPloca.Naziv.ToString();
            slika.Source = new BitmapImage(new System.Uri(App.IzabranaMaticnaPloca.UrlSlike.ToString(), UriKind.Absolute));
            //TODO:
            //unosRtf.Source = App.IzabranaMaticnaPloca.UrlRtf;
            datum.Text = App.IzabranaMaticnaPloca.DatumDodavanja.ToString();

            InitializeComponent();            
        }

        private void ReturnBtn_Click(object sender, RoutedEventArgs e)
        {
            // Vrati se na tabelu
            NavigationService navService = NavigationService.GetNavigationService(this);
            navService.Navigate(new System.Uri("/Frames/Table.xaml", UriKind.Relative));
        }
    }
}
