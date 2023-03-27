using ContentManagementSystem;
using ContentManagementSystem.Windows;
using System;
using System.Collections.Generic;
using System.IO;
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
        #region INICIJALIZACIJA
        public Table()
        {
            InitializeComponent();

            // Okidač DataBinding-a
            DataContext = this;
            dataGridSveMaticnePloce.ItemsSource = MainWindow.Skladiste;

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
        #endregion

        #region ODJAVA
        // Dugme za odjavu
        private void LogoutBtn_Click(object sender, RoutedEventArgs e)
        {
            App.AdminUser = false;
            NavigationService navService = NavigationService.GetNavigationService(this);
            navService.Navigate(new System.Uri("/Frames/Login.xaml", UriKind.Relative));
        }
        #endregion

        #region DODAJ NOVO
        // Dugme za dodavanje novih matičnih ploča
        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService navService = NavigationService.GetNavigationService(this);
            navService.Navigate(new System.Uri("/Frames/AddNewMb.xaml", UriKind.Relative));
        }
        #endregion

        #region OBRIŠI IZABRANO
        // Dugme za brisanje izabranih
        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            if (MainWindow.Skladiste.Count > 0)
            { 
                // Potvrda brisanja
                DeletionConfirmation dc = new DeletionConfirmation();
                dc.ShowDialog();

                if (dc.Potvrda)
                {
                    int temp = 1;
                    MaticnaPloca mb;

                    // Koji sam ja genije (dužina kolekcije se stalno menja, zato mora uslovan inkrement)
                    for (int i = 0; i < MainWindow.Skladiste.Count; i += temp)
                    {
                        mb = MainWindow.Skladiste[i];
                        if (mb.Brisanje)
                        {
                            try
                            {
                                string fajl = new System.Uri(mb.UrlRtf, UriKind.Relative).ToString();
                                File.Delete(fajl);
                                MainWindow.Skladiste.Remove(mb);

                                temp = 0;
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }                            
                        }
                        else
                        {
                            temp = 1;
                        }
                    }
                }                    
            }
            else
            {
                MessageBox.Show("Skladište je prazno.", "Obaveštenje", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }
        #endregion

        #region HYPERLINK
        // Pregled/izmena ploče
        private void OnHyperlink_Click(object sender, RoutedEventArgs e)
        {
            // Postavljanje reference na izabrani objekat
            App.IzabranaMaticnaPloca = MainWindow.Skladiste.ElementAt(dataGridSveMaticnePloce.SelectedIndex);

            // Otvaranje odgovarajućeg prozora u zavisnosti od vrste korisnika
            if (App.AdminUser)
            {
                // Admin - izmena ploče
                NavigationService navService = NavigationService.GetNavigationService(this);
                navService.Navigate(new System.Uri("/Frames/UpdateMb.xaml", UriKind.Relative));
            }
            else
            {
                // Ostali - pregled ploče
                NavigationService navService = NavigationService.GetNavigationService(this);
                navService.Navigate(new System.Uri("/Frames/ViewMb.xaml", UriKind.Relative));
            }            
        }
        #endregion HYPERLINK
    }
}
