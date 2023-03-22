using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace ContentManagementSystem
{
    public partial class App : Application
    {
        // Statičko polje za ID proizvoda (inkrement se vrši pri pozivanju konstruktora)
        private static int idProizvoda = 0;
        public static int IdProizvoda { get => idProizvoda; set => idProizvoda = value; }

        // Privremene reference na izabrane objekte (za izmenu i pregled)
        private static MaticnaPloca izabranaMaticnaPloca = null;
        public static MaticnaPloca IzabranaMaticnaPloca { get => izabranaMaticnaPloca; set => izabranaMaticnaPloca = value; }

        // Kolekcija za matične ploče
        private static ObservableCollection<MaticnaPloca> svePloce = new ObservableCollection<MaticnaPloca>();
        public static ObservableCollection<MaticnaPloca> SvePloce { get => svePloce; set => svePloce = value; }

        // Da li je korisnik admin?
        private static bool adminUser = false;
        public static bool AdminUser { get => adminUser; set => adminUser = value; }
    }
}
