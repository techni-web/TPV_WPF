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
            this.Cursor = Cursors.Wait;
            InitializeComponent();
            this.Cursor = Cursors.Arrow;
            
        }

        private void about_Loaded(object sender, RoutedEventArgs e)
        {
            
        }

        private void pgBarInicio_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void Storyboard_Completed(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Wait;
            Forms.FEnBlanco frmEnBlanco = new Forms.FEnBlanco();
            frmEnBlanco.Show();
            frmEnBlanco = null;
            //MainWindow objMainWindow = new MainWindow();
            //objMainWindow.ShowDialog();
            //objMainWindow = null;
            this.Close();
            //this.Dispatcher.InvokeShutdown();
            this.Cursor = Cursors.Arrow;
        }
    }
}
