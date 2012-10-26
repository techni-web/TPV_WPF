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
using System.Data;

namespace TPVTAC_WPF.Forms
{
    /// <summary>
    /// Lógica de interacción para LogIn.xaml
    /// </summary>
    public partial class LogIn : Window
    {
        dbUsuarios _modUsuarios = new dbUsuarios();

        public LogIn()
        {
            this.Cursor = Cursors.Wait;
            InitializeComponent();
            txtUsuario.Focus();
            this.Cursor = Cursors.Arrow;
        }

        private void btnAceptar_Click(object sender, RoutedEventArgs e)
        {
            if (txtUsuario.Text.Length > 0)
            {
                FvalidaUsuario();
            }
            else
            {
                MessageBox.Show("Favor de capturar el Usuario");
            }
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void FvalidaUsuario()
        {
            String _pswd;
            DataTable dtUsuarios = new DataTable();
            if (_modUsuarios.validaUsuario(txtUsuario.Text, out dtUsuarios))
            {
                if (dtUsuarios.Rows.Count > 0)
                {
                    DataRow dtrow = dtUsuarios.Rows[0];
                    _pswd = dtrow["PWD"].ToString().Trim();
                    if (_pswd == txtPassword.Password.Trim())
                    {
                        DialogResult = true;
                    }
                    else
                    {
                        MessageBox.Show("Usuario o Contraseña Incorrectos");
                    }
                }
                else
                {
                    MessageBox.Show("Usuario o Contraseña Incorrectos");
                }

            }

        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

    }
}
