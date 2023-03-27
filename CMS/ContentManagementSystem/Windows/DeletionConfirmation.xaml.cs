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
using System.Windows.Shapes;

namespace ContentManagementSystem.Windows
{
    public partial class DeletionConfirmation : Window
    {
        // Da li je potvrđeno brisanje ili ne
        private bool potvrda;
        public bool Potvrda { get => potvrda; set => potvrda = value; }

        #region  INICIJALIZACIJA
        public DeletionConfirmation()
        {
            this.potvrda = false;
            InitializeComponent();
        }
        #endregion

        #region DA
        // Briši
        private void ConfirmBtn_Click(object sender, RoutedEventArgs e)
        {
            potvrda = true;
            Close();
        }
        #endregion

        #region NE
        // Ne briši
        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            potvrda = false;
            Close();
        }
        #endregion
    }
}
