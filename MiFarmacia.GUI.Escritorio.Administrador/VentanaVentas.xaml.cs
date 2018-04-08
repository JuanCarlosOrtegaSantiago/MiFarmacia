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

namespace MiFarmacia.GUI.Escritorio.Administrador
{
    /// <summary>
    /// Lógica de interacción para VentanaVentas.xaml
    /// </summary>
    public partial class VentanaVentas : Window
    {
        public VentanaVentas()
        {
            InitializeComponent();
        }

        private void btnRegresar_Click(object sender, RoutedEventArgs e)
        {
            MainWindow pagina = new MainWindow();
            pagina.Show();
            this.Close();
        }

        private void btnNuevaVenta_Click(object sender, RoutedEventArgs e)
        {
            VentanaNuevaVenta pagina = new VentanaNuevaVenta();
            pagina.Show();
            this.Close();
        }
    }
}
