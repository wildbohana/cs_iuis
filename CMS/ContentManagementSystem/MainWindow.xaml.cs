using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net.Security;
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

namespace ContentManagementSystem
{
    public partial class MainWindow : Window
    {
        public static int indeks;
        private DataIO serializer = new DataIO();
        public static BindingList<MaticnaPloca> Skladiste { get; set; }

        #region POKRETANJE PROGRAMA
        public MainWindow()
        {
            // Učitavanje objekata iz datoteke u listu
            Skladiste = serializer.DeSerializeObject<BindingList<MaticnaPloca>>("sacuvane_ploce.xml");
            if (Skladiste == null) Skladiste = new BindingList<MaticnaPloca>();

            // Učitavanje indeksa iz fajla
            indeks = UcitajIndeks();

            InitializeComponent();
        }
        #endregion

        #region IZLAZAK IZ PROGRAMA
        // Pri izlasku iz programa, sačuvati sve izmene u fajl
        private void Save(object sender, CancelEventArgs e)
        {
            // Čuvanje objekata iz liste u datoteku
            serializer.SerializeObject<BindingList<MaticnaPloca>>(Skladiste, "sacuvane_ploce.xml");

            // Čuvanje trenutnog indeksa
            SacuvajIndeks(indeks);
        }
        #endregion

        #region UČITAJ INDEKS
        private int UcitajIndeks()
        {
            int retval = 0;
            StreamReader sr = null;
            string procitano;

            try
            {
                sr = new StreamReader("idx.txt");
                FileStream fs = new FileStream("idx.txt", FileMode.Open, FileAccess.Read);  

                if (fs != null)
                {
                    if ((procitano = sr.ReadLine()) != null) 
                        retval = Convert.ToInt32(procitano);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Грешка приликом учитавања индекса!", "Грешка!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                if (sr != null) sr.Close();
            }

            return retval;
        }
        #endregion

        #region SAČUVAJ INDEKS
        private void SacuvajIndeks(int broj)
        {
            StreamWriter sw = null;

            try
            {
                sw = new StreamWriter("idx.txt");
                sw.WriteLine(broj.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Грешка приликом чувања индекса!", "Грешка!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                if (sw != null) sw.Close();
            }
        }
        #endregion
    }
}
