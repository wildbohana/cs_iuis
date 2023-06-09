﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using System.Windows;
using System.Windows.Controls;

namespace ContentManagementSystem
{
    public class OdabirPutanje
    {
        private string trenutnaPutanja = string.Empty;

        public string Odabir_Putanje(Image slika)
        {
            var dialog = new Microsoft.Win32.OpenFileDialog();
            dialog.FileName = "";
            dialog.DefaultExt = ".png";
            dialog.Filter = "Слика (.png)|*.png";

            bool? result = dialog.ShowDialog();

            if (result == true)
            {
                trenutnaPutanja = dialog.FileName;
                slika.Source = new BitmapImage(new Uri(trenutnaPutanja, UriKind.Absolute));
            }
            else
            {
                MessageBox.Show("Нисте одабрали слику!", "Грешка!", MessageBoxButton.OK, MessageBoxImage.Error);
                slika.Source = new BitmapImage(new System.Uri("/Images/placeholder.png", UriKind.Relative));
                trenutnaPutanja = string.Empty;
            }

            return trenutnaPutanja;
        }
    }
}
