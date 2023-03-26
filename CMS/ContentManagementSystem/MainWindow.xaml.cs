using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace ContentManagementSystem
{
    public partial class MainWindow : Window
    {
        private DataIO serializer = new DataIO();
//        private static BindingList<MaticnaPloca> skladiste = new BindingList<MaticnaPloca>();

        public static BindingList<MaticnaPloca> Skladiste { get; set; }

        public MainWindow()
        {
            Skladiste = serializer.DeSerializeObject<BindingList<MaticnaPloca>>("sacuvane_ploce.xml");
            if (Skladiste == null)
            {
                Skladiste = new BindingList<MaticnaPloca>();
            }

            // Okidac DataBinding-a
            DataContext = this;

            InitializeComponent();
        }

        // Pri izlasku iz programa, sačuvati sve izmene u fajl
        private void Save(object sender, CancelEventArgs e)
        {
            serializer.SerializeObject<BindingList<MaticnaPloca>>(Skladiste, "sacuvane_ploce.xml");
        }
    }
}
