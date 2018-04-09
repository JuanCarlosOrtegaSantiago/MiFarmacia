using MiFarmacia.BIZ;
using MiFarmacia.COMMON.Entidades;
using MiFarmacia.DAL;
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
    /// Lógica de interacción para VEntanaReguistroDeVales.xaml
    /// </summary>
    public partial class VEntanaReguistroDeVales : Window
    {
        ManejadorTiked manejadorTiked;

        public VEntanaReguistroDeVales()
        {
            InitializeComponent();
            manejadorTiked = new ManejadorTiked(new TikedRepositorio());

            ActualziarTabla();
        }

        private void ActualziarTabla()
        {
            dtgTikeds.ItemsSource = null;
            dtgTikeds.ItemsSource = manejadorTiked.Listar;
        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            Tiked tiked = dtgTikeds.SelectedItem as Tiked;
            if (tiked != null)
            {
                if(MessageBox.Show("Realmente deseas elimnar esta venta", "Advertencia", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {
                    if (manejadorTiked.Eliminar(tiked.Id))
                    {
                        MessageBox.Show("Eliminado con exito", "", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                        ActualziarTabla();
                    }
                    else
                    {
                        MessageBox.Show("Algo salio mal", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
        }

        private void btnRegresar_Click(object sender, RoutedEventArgs e)
        {
            VentanaVentas pagina = new VentanaVentas();
            pagina.Show();
            this.Close();
        }
    }
}
