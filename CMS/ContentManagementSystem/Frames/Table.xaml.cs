using ContentManagementSystem;
using ContentManagementSystem.Windows;
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
    public partial class Table : Page
    {
        private List<int> deleteIndexes = new List<int>();
        private Dictionary<int, MaticnaPloca> spisakPloca = new Dictionary<int, MaticnaPloca>();

        public Table()
        {
            InitializeComponent();

            if (App.AdminUser)
            {
                adminPanel.Visibility = Visibility.Visible;
                izborZaBrisanje.IsReadOnly = false;
            }
            else
            {
                adminPanel.Visibility = Visibility.Hidden;
                izborZaBrisanje.IsReadOnly = true;
            }
        }

        // Dugme za odjavu
        private void LogoutBtn_Click(object sender, RoutedEventArgs e)
        {
            App.AdminUser = false;
            NavigationService navService = NavigationService.GetNavigationService(this);
            navService.Navigate(new System.Uri("/Frames/Login.xaml", UriKind.Relative));
        }

        // Dugme za dodavanje novih matičnih ploča
        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService navService = NavigationService.GetNavigationService(this);
            navService.Navigate(new System.Uri("/Frames/AddNewMb.xaml", UriKind.Relative));
        }

        // Dugme za brisanje izabranih
        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            // Potvrda brisanja
            DeletionConfirmation dc = new DeletionConfirmation();
            dc.ShowDialog();

            if (dc.Potvrda)
                foreach (int idx in deleteIndexes)
                    spisakPloca.Remove(idx);

            // Za svaki slučaj ga vraćam na netačno
            dc.Potvrda = false;
        }
    }
}
