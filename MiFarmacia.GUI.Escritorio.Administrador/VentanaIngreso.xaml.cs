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
    /// Lógica de interacción para VentanaIngreso.xaml
    /// </summary>
    public partial class VentanaIngreso : Window
    {
        public VentanaIngreso()
        {
            InitializeComponent();
            LimpiarCajas();
            lblError.Visibility = Visibility.Hidden;
        }

        private void LimpiarCajas()
        {
            tbxUsuario.Clear();
            pwbxContrasena.Clear();
        }

        private void btnRegresar_Click(object sender, RoutedEventArgs e)
        {
            MainWindow pagina = new MainWindow();
            pagina.Show();
            this.Close();
        }

        private void btnAceptar_Click(object sender, RoutedEventArgs e)
        {
            if(string.IsNullOrWhiteSpace(tbxUsuario.Text)|| string.IsNullOrWhiteSpace(pwbxContrasena.Password))
            {
                if (MessageBox.Show("Faltan datos por llenar ", "Error", MessageBoxButton.OK, MessageBoxImage.Exclamation) == MessageBoxResult.OK)
                {
                    LimpiarCajas();
                    return;
                }
            }

            if (tbxUsuario.Text != "juankx" || pwbxContrasena.Password != "juankx99stx")
            {
                lblError.Visibility = Visibility.Visible;
                LimpiarCajas();
                return;
            }

            if (tbxUsuario.Text == "juankx" && pwbxContrasena.Password == "juankx99stx")
            {
                VentanaTablas pagina =new VentanaTablas();
                pagina.Show();
                this.Close();
            }
        }
    }
}
