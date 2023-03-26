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
    // DATAGRID.SELECTEDINDEX !!!
    public partial class Table : Page
    {
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
            if (MainWindow.Skladiste.Count > 0)
            { 
                // Potvrda brisanja
                DeletionConfirmation dc = new DeletionConfirmation();
                dc.ShowDialog();

                if (dc.Potvrda)
                    foreach (MaticnaPloca mb in MainWindow.Skladiste)
                        if (mb.Brisanje)
                            MainWindow.Skladiste.Remove(mb);
            }
            else
            {
                MessageBox.Show("Skladište je prazno.", "Obaveštenje", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }

        // Za update/view 
        // TODO: jel ovo ovako treba?
        //App.IzabranaMaticnaPloca = dataGridSveMaticnePloce.SelectedItem as MaticnaPloca;

        // TODO: Click on hyperlink (proveri da li je App.UserAdmin, pa otvori View/Update)
        // TODO: Napravi Hyperlink polje
    }
}
