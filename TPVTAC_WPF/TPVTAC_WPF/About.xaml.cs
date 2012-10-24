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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Threading;


namespace TPVTAC_WPF
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class About : Window
    {
        public About()
        {
            InitializeComponent();
            
        }

        private void about_Loaded(object sender, RoutedEventArgs e)
        {
            pgBarInicio.Value = 0;
            for (var i = 0; i <= 100; i++)
            {
                pgBarInicio.Value = i;
            }
        }

        private void pgBarInicio_Loaded(object sender, RoutedEventArgs e)
        {
            Forms.FEnBlanco frmEnBlanco = new Forms.FEnBlanco();
            frmEnBlanco.Show();
            this.Close();
        }
    }
}
