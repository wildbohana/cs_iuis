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
    public partial class UpdateMb : Page
    {
        private string trenutnaPutanjaSlika = string.Empty;
        private string trenutnaPutanjaRtf = string.Empty;

        public UpdateMb()
        {
            //imageSlika.Source = new BitmapImage(App.IzabranaMaticnaPloca.UrlSlika);

            // Mora prvo inicijalizacija
            InitializeComponent();

            // Tek kasnije ide podešavanje ItemsSource za ComboBox
            ComboBoxFamily.ItemsSource = Fonts.SystemFontFamilies.OrderBy(f => f.Source);
            ComboBoxSize.ItemsSource = new List<double> { 8, 9, 10, 11, 12, 14, 16, 18, 20, 22, 24, 26, 28, 30 };
            ComboBoxFamily.SelectedIndex = 2;
            ComboBoxColor.ItemsSource = new List<string>() { "Black", "White", "Yellow", "Red", "Purple", "Orange", "Green", "Brown", "Blue" };
            ComboBoxColor.SelectedIndex = 0;

            slika.Source = new BitmapImage(new System.Uri(App.IzabranaMaticnaPloca.UrlSlike.ToString(), UriKind.Absolute));
            //TODO:
            // unosRTF.Source = ...
        }

        // Odustajanje od izmena
        private void ReturnBtn_Click(object sender, RoutedEventArgs e)
        {
            // TODO:
            // Isprazni sve TextBlock prvo

            // Vrati se na tabelu
            NavigationService navService = NavigationService.GetNavigationService(this);
            navService.Navigate(new System.Uri("/Frames/Table.xaml", UriKind.Relative));
        }

        // Potvrda izmena
        private void ConfirmBtn_Click(object sender, RoutedEventArgs e)
        {
            // TODO:
            // Sačuvaj sve izmene
            try
            {
                int gp = int.Parse(godina.Text);
                string nz = model.Text;
                string url1 = trenutnaPutanjaSlika;
                string url2 = trenutnaPutanjaRtf;

                App.IzabranaMaticnaPloca.GodinaProizvodnje = gp;
                App.IzabranaMaticnaPloca.Naziv = nz;
                App.IzabranaMaticnaPloca.UrlSlike = url1;
                App.IzabranaMaticnaPloca.UrlRtf = url2;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            // TODO:
            // Isprazni sve TextBlock

            // Vrati se na tabelu
            NavigationService navService = NavigationService.GetNavigationService(this);
            navService.Navigate(new System.Uri("/Frames/Table.xaml", UriKind.Relative));
        }

        // Biranje slike
        private void AddImageBtn_Click(object sender, RoutedEventArgs e)
        {
            OdabirPutanje odabir = new OdabirPutanje();
            trenutnaPutanjaSlika = odabir.Odabir_Putanje(slika);
        }

        //////////////////////////////////// RichTextBox ////////////////////////////////////

        // TODO: Trebam još da nađem način da otvaram i čuvam RTF datoteku

        // ComboBox za izmene
        private void ComboBoxFamily_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ComboBoxFamily.SelectedItem != null && !unosRTB.Selection.IsEmpty)
            {
                unosRTB.Selection.ApplyPropertyValue(Inline.FontFamilyProperty, ComboBoxFamily.SelectedItem);
            }
        }

        private void ComboBoxSize_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ComboBoxSize.SelectedValue != null && !unosRTB.Selection.IsEmpty)
            {
                unosRTB.Selection.ApplyPropertyValue(Inline.FontSizeProperty, ComboBoxSize.SelectedValue);
            }
        }

        private void ComboBoxColor_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ComboBoxColor.SelectedValue != null && !unosRTB.Selection.IsEmpty)
            {
                unosRTB.Selection.ApplyPropertyValue(Inline.ForegroundProperty, ComboBoxColor.SelectedValue);
            }
        }

        // Unos u RichTextBox
        private void unosRTB_SelectionChanged(object sender, RoutedEventArgs e)
        {
            object temp = unosRTB.Selection.GetPropertyValue(Inline.FontStyleProperty);
            tglButtonItalic.IsChecked = (temp != DependencyProperty.UnsetValue) && (temp.Equals(FontStyles.Italic));

            temp = unosRTB.Selection.GetPropertyValue(Inline.FontWeightProperty);
            tglButtonBold.IsChecked = (temp != DependencyProperty.UnsetValue) && (temp.Equals(FontWeights.Bold));

            temp = unosRTB.Selection.GetPropertyValue(Inline.TextDecorationsProperty);
            tglButtonUnderline.IsChecked = (temp != DependencyProperty.UnsetValue) && (temp.Equals(TextDecorations.Underline));

            temp = unosRTB.Selection.GetPropertyValue(Inline.FontFamilyProperty);
            ComboBoxFamily.SelectedItem = temp;

            temp = unosRTB.Selection.GetPropertyValue(Inline.FontSizeProperty);
            ComboBoxSize.Text = temp.ToString();

            temp = unosRTB.Selection.GetPropertyValue(Inline.ForegroundProperty);
        }

        // Brojač reči
        private void BrojacReci()
        {
            int count = 0;
            int index = 0;
            string richText = new TextRange(unosRTB.Document.ContentStart, unosRTB.Document.ContentEnd).Text;

            // Preskače razmake do prve reči
            while (index < richText.Length && char.IsWhiteSpace(richText[index])) index++;
            while (index < richText.Length)
            {
                // Provera da li je trenutni karakter deo reči
                while (index < richText.Length && !char.IsWhiteSpace(richText[index])) index++;

                // Povećava brojač za jedan (jer smo pronašli jednu novu reč)
                count++;

                // Preskače razmake do naredne reči
                while (index < richText.Length && char.IsWhiteSpace(richText[index])) index++;
            }

            brojReci.Text = count.ToString();
        }

        // Svaki unos novog karaktera pokreće BrojacReci()
        private void unosRTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            BrojacReci();
        }
    }
}
