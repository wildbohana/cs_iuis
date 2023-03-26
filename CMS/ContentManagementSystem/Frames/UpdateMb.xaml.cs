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
    public partial class UpdateMb : Page
    {
        // Ovo ne radi jer se string za putanju izvlači iz klase!
        // private string trenutnaPutanja = new Uri("/src/placeholder.png", UriKind.Relative).ToString();
        private string trenutnaPutanja = string.Empty;

        public UpdateMb()
        {
            InitializeComponent();
        }

        // Odustajanje od izmena
        private void ReturnBtn_Click(object sender, RoutedEventArgs e)
        {
            // Isprazni sve TextBlock prvo

            // Vrati se na tabelu
            NavigationService navService = NavigationService.GetNavigationService(this);
            navService.Navigate(new System.Uri("/Frames/Table.xaml", UriKind.Relative));
        }

        // Potvrda izmena
        private void ConfirmBtn_Click(object sender, RoutedEventArgs e)
        {
            // Dodaj novi

            // Isprazni sve TextBlock

            // Vrati se na tabelu
            NavigationService navService = NavigationService.GetNavigationService(this);
            navService.Navigate(new System.Uri("/Frames/Table.xaml", UriKind.Relative));
        }

        // Biranje slike
        private void addImageBtn_Click(object sender, RoutedEventArgs e)
        {
            OdabirPutanje odabir = new OdabirPutanje();
            trenutnaPutanja = odabir.Odabir_Putanje(slika);
        }
    }
}
