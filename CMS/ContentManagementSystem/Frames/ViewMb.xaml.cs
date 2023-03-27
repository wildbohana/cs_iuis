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
        #region INICIJALIZACIJA
        public ViewMb()
        {
            // Mora prvo inicijalizacija
            InitializeComponent();

            // TODO: OBRIŠI - OVO JE SAMO ZA TESTIRANJE
            //App.IzabranaMaticnaPloca = MainWindow.Skladiste.ElementAt(1);

            // Popunjavane polja sa podacima o ploči koju menjamo
            model.Text = App.IzabranaMaticnaPloca.Naziv;
            godina.Text = App.IzabranaMaticnaPloca.GodinaProizvodnje.ToString();
            datum.Text = App.IzabranaMaticnaPloca.DatumDodavanja.ToShortDateString();
            slika.Source = new BitmapImage(new System.Uri(App.IzabranaMaticnaPloca.UrlSlike.ToString(), UriKind.Absolute));

            TextRange textRange;
            System.IO.FileStream fileStream;

            if (System.IO.File.Exists(App.IzabranaMaticnaPloca.UrlRtf))
            {
                textRange = new TextRange(unosRTB.Document.ContentStart, unosRTB.Document.ContentEnd);
                using (fileStream = new System.IO.FileStream(App.IzabranaMaticnaPloca.UrlRtf, System.IO.FileMode.OpenOrCreate))
                {
                    textRange.Load(fileStream, System.Windows.DataFormats.Rtf);
                }
            }
        }
        #endregion

        #region POVRATAK NAZAD
        private void ReturnBtn_Click(object sender, RoutedEventArgs e)
        {
            // Referenca za izabranu ploču na null
            App.IzabranaMaticnaPloca = null;

            // Vrati se na tabelu
            NavigationService navService = NavigationService.GetNavigationService(this);
            navService.Navigate(new System.Uri("/Frames/Table.xaml", UriKind.Relative));
        }
        #endregion
    }
}
