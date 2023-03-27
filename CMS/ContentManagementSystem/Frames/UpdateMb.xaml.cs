using System;
using System.Collections.Generic;
using System.IO;
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

        #region INICIJALIZACIJA
        public UpdateMb()
        {
            // Mora prvo inicijalizacija
            InitializeComponent();

            // Podešavanja za RichTextBox
            ComboBoxFamily.ItemsSource = Fonts.SystemFontFamilies.OrderBy(f => f.Source);
            ComboBoxSize.ItemsSource = new List<double> { 8, 9, 10, 11, 12, 14, 16, 18, 20, 22, 24, 26, 28, 30 };
            ComboBoxFamily.SelectedIndex = 2;
            ComboBoxColor.ItemsSource = new List<string>() { "Black", "White", "Yellow", "Red", "Purple", "Orange", "Green", "Brown", "Blue" };
            ComboBoxColor.SelectedIndex = 0;

            // Popunjavane polja sa podacima o ploči koju menjamo
            trenutnaPutanjaSlika = App.IzabranaMaticnaPloca.UrlSlike.ToString();

            model.Text = App.IzabranaMaticnaPloca.Naziv;
            godina.Text = App.IzabranaMaticnaPloca.GodinaProizvodnje.ToString();
            slika.Source = new BitmapImage(new System.Uri(trenutnaPutanjaSlika, UriKind.Absolute));

            trenutnaPutanjaRtf = App.IzabranaMaticnaPloca.UrlRtf;
            TextRange textRange;
            System.IO.FileStream fileStream;

            if (System.IO.File.Exists(trenutnaPutanjaRtf))
            {
                textRange = new TextRange(unosRTB.Document.ContentStart, unosRTB.Document.ContentEnd);
                using (fileStream = new System.IO.FileStream(trenutnaPutanjaRtf, System.IO.FileMode.OpenOrCreate))
                {
                    textRange.Load(fileStream, System.Windows.DataFormats.Rtf);
                }
            }
        }
        #endregion

        #region ODUSTAJANJE OD IZMENA
        // Odustanak od izmena
        private void ReturnBtn_Click(object sender, RoutedEventArgs e)
        {
            // Referenca na null
            App.IzabranaMaticnaPloca = null;

            // Vrati se na tabelu
            NavigationService navService = NavigationService.GetNavigationService(this);
            navService.Navigate(new System.Uri("/Frames/Table.xaml", UriKind.Relative));
        }
        #endregion

        #region IZBOR SLIKE
        // Biranje slike
        private void AddImageBtn_Click(object sender, RoutedEventArgs e)
        {
            OdabirPutanje odabir = new OdabirPutanje();
            trenutnaPutanjaSlika = odabir.Odabir_Putanje(slika);
        }
        #endregion

        #region DODAVANJE NOVOG
        // Potvrda čuvanja izmena
        private void ConfirmBtn_Click(object sender, RoutedEventArgs e)
        {
            if (validate())
            {
                try
                {
                    TextRange textRange;
                    FileStream fileStream;
                    textRange = new TextRange(unosRTB.Document.ContentStart, unosRTB.Document.ContentEnd);
                    fileStream = new FileStream(trenutnaPutanjaRtf, FileMode.Create);
                    textRange.Save(fileStream, DataFormats.Rtf);
                    fileStream.Close();

                    App.IzabranaMaticnaPloca.GodinaProizvodnje = int.Parse(godina.Text);
                    App.IzabranaMaticnaPloca.Naziv = model.Text;
                    App.IzabranaMaticnaPloca.UrlSlike = trenutnaPutanjaSlika;

                    // Referencu na izabranu ploču vrati na null
                    App.IzabranaMaticnaPloca = null;

                    // Vrati se na tabelu
                    NavigationService navService = NavigationService.GetNavigationService(this);
                    navService.Navigate(new System.Uri("/Frames/Table.xaml", UriKind.Relative));
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Greška!", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Popunite sva polja!", "Greška", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        #endregion

        #region VALIDACIJA
        // Pozvana prilikom klika na dugme za dodavanje novog
        private bool validate()
        {
            bool result = true;

            // Naziv modela
            if (model.Text.Trim().Equals(""))
            {
                result = false;
                model.Foreground = Brushes.Red;
                model.BorderBrush = Brushes.Red;
                model.BorderThickness = new Thickness(1);
            }
            else
            {
                model.Foreground = Brushes.Black;
                model.BorderBrush = Brushes.Green;
                model.BorderThickness = new Thickness(1);
            }

            // Godina proizvodnje
            if (godina.Text.Trim().Equals(""))
            {
                result = false;
                godina.Foreground = Brushes.Red;
                godina.BorderBrush = Brushes.Red;
                godina.BorderThickness = new Thickness(1);
            }
            else
            {
                bool isNumeric = int.TryParse(godina.Text, out _);

                if (isNumeric)
                {
                    if (Int32.Parse(godina.Text) > 1980 && Int32.Parse(godina.Text) < 2023)
                    {
                        godina.Foreground = Brushes.Black;
                        godina.BorderBrush = Brushes.Green;
                        godina.BorderThickness = new Thickness(1);
                    }
                    else
                    {
                        result = false;
                        godina.Foreground = Brushes.Red;
                        godina.BorderBrush = Brushes.Red;
                        godina.BorderThickness = new Thickness(1);
                    }
                }
                else
                {
                    result = false;
                    godina.Foreground = Brushes.Red;
                    godina.BorderBrush = Brushes.Red;
                    godina.BorderThickness = new Thickness(1);
                }
            }

            // UrlSlika
            if (trenutnaPutanjaSlika.Equals(String.Empty))
            {
                result = false;
                okvirSlike.BorderBrush = Brushes.Red;
                okvirSlike.BorderThickness = new Thickness(1);
            }
            else
            {
                okvirSlike.BorderBrush = Brushes.Green;
                okvirSlike.BorderThickness = new Thickness(1);
            }

            return result;
        }
        #endregion

        #region RICHTEXTBOX
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
        #endregion
    }
}
