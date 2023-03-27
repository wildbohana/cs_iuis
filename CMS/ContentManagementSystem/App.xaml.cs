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
        // Privremene reference na izabrane objekte (za izmenu i pregled)
        private static MaticnaPloca izabranaMaticnaPloca = null;
        public static MaticnaPloca IzabranaMaticnaPloca { get => izabranaMaticnaPloca; set => izabranaMaticnaPloca = value; }

        // Da li je korisnik admin?
        private static bool adminUser = false;
        public static bool AdminUser { get => adminUser; set => adminUser = value; }
    }
}
