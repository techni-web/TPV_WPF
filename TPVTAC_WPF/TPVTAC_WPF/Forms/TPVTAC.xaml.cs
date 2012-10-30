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
using VIBlend;
using System.Windows.Controls.Primitives;
using System.Data;

namespace TPVTAC_WPF.Forms
{
    /// <summary>
    /// Lógica de interacción para TPVTAC.xaml
    /// </summary>
    public partial class TPVTAC : Window
    {

        dbZonas _modZonas = new dbZonas();

        public TPVTAC()
        {
            InitializeComponent();
        }

        private void ftpvt_Loaded(object sender, RoutedEventArgs e)
        {

            //VER ICONOS DEL USUARIO

            //VER ZONAS PERSONALIZADAS PARA EL USUARIO
            DataTable dtZonas = new DataTable();
            if (_modZonas.getZonas(out dtZonas))
            {
                foreach(DataRow dtrow in dtZonas.Rows)
                {
                    ToggleButton tb = new ToggleButton();
                    tb.Width = 100;
                    tb.Height = PnlZonas.Height;
                    tb.Checked += chkbox_Checked;
                    tb.IsChecked = false;
                    tb.MouseDown += Toggle_MouseDown;
                    tb.Click += BtnZona_Click;
                    tb.Tag = dtrow["500ID"].ToString().Trim();
                    tb.Content = dtrow["500NOMBRE"].ToString().Trim();
                    PnlZonas.Children.Add(tb);
                }
            }

            
        }

        void chkbox_Checked(object sender, RoutedEventArgs e)
        {
            var ThisController = sender as ToggleButton;
            foreach(Control c in PnlZonas.Children)
            {
	            if(c.GetType() == typeof(ToggleButton))
	            {
                    if (ThisController != c)
                    {
                        ToggleButton tb = (ToggleButton)c;
                        tb.IsChecked = false;
                    }
	            }
            }
        }

        private void Toggle_MouseDown(object sender, MouseButtonEventArgs e)
        {
            //var ThisController = sender as ToggleButton;
            
        }

        // Event hanlder for dragging functionality support
        private void onDragDelta(object sender, System.Windows.Controls.Primitives.DragDeltaEventArgs e)
        {
            miMesa thumb = e.Source as miMesa;

            double left = Canvas.GetLeft(thumb) + e.HorizontalChange;
            double top = Canvas.GetTop(thumb) + e.VerticalChange;

            Canvas.SetLeft(thumb, left);
            Canvas.SetTop(thumb, top);

            // Update lines's layouts
            //UpdateLines(thumb);
        }

        private void BtnZona_Click(object sender, RoutedEventArgs e)
        {
            var ThisToggle = sender as ToggleButton;
            DataTable dtMesas = new DataTable();
            if (_modZonas.getMesasporZonas(ThisToggle.Tag.ToString(), out dtMesas))
            {
                foreach (DataRow dtrow in dtMesas.Rows)
                {
                    miMesa objMesa = new miMesa();
                    objMesa.Template = (ControlTemplate)Resources["tmpMesa"];
                    objMesa.DragDelta += onDragDelta;
                    //objMesa.Width = Convert.ToInt32(dtrow["501ANCHO"].ToString());
                    //objMesa.Height = Convert.ToInt32(dtrow["501ALTO"].ToString());
                    objMesa.SetValue(Canvas.LeftProperty, Convert.ToDouble(dtrow["501POS_X"]));
                    objMesa.SetValue(Canvas.TopProperty, Convert.ToDouble(dtrow["501POS_Y"]));
                    cnvMesas.Children.Add(objMesa);
                    cnvMesas.InvalidateVisual();
                }
            }
        }

    }
}
