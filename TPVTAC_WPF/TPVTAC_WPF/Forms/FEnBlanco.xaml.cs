using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace TPVTAC_WPF.Forms
{
    /// <summary>
    /// Lógica de interacción para FEnBlanco.xaml
    /// </summary>
    public partial class FEnBlanco : Window
    {
        public FEnBlanco()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Forms.LogIn frmLogIn = new Forms.LogIn();
            frmLogIn.ShowDialog();
            if (frmLogIn.DialogResult.HasValue && frmLogIn.DialogResult.Value)
            {
                TPVTAC frmPrincipal = new TPVTAC();
                frmPrincipal.Show();
                this.Close();
                
            }
        }
    }
}
