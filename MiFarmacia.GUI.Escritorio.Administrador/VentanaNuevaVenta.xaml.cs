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
    /// Lógica de interacción para VentanaNuevaVenta.xaml
    /// </summary>
    public partial class VentanaNuevaVenta : Window
    {
        ManejadorEmpleados manejadorEmpleados;
        ManejadorClientes manejadorClientes;
        ManejadorProductos manejadorProductos;

        Tiked tiked;
        float suma;
        enum accion
        {
            nuevo
        }

        accion accionvale;

        public VentanaNuevaVenta()
        {
            InitializeComponent();
            manejadorEmpleados = new ManejadorEmpleados(new EmpleadoRepositorio());
            manejadorClientes = new ManejadorClientes(new ClienteRepositorio());
            manejadorProductos = new ManejadorProductos(new ProductoRepositorios());

            HabiltarBotones(false);
            HabilitarCajasYCombos(false);
            LimparCajas();
            ActualizarCombos();
        }

        private void ActualizarCombos()
        {
            cmbxCliente.ItemsSource = null;
            cmbxCliente.ItemsSource = manejadorClientes.Listar;

            cmbxEmpleado.ItemsSource = null;
            cmbxEmpleado.ItemsSource = manejadorEmpleados.Listar;

            cmbxProducto.ItemsSource = null;
            cmbxProducto.ItemsSource = manejadorProductos.Listar;
        }

        private void HabiltarBotones(bool habilitada)
        {
            btnAceptarVenta.IsEnabled = habilitada;
            btnCancelarVenta.IsEnabled = habilitada;
            btnNuevaVenta.IsEnabled = !habilitada;
            btnRegresar.IsEnabled = !habilitada;
        }

        private void LimparCajas()
        {
            tbxCantidadDelProducto.Clear();
            txblkTotalAPagar.Text = "";
            cmbxCliente.Text = null;
            cmbxEmpleado.Text = null;
            cmbxProducto.Text = null;
            dtgProductos.ItemsSource = null;
        }

        private void HabilitarCajasYCombos(bool habilitada)
        {
            tbxCantidadDelProducto.IsEnabled = habilitada;
            cmbxProducto.IsEnabled = habilitada;
            cmbxCliente.IsEnabled = habilitada;
            cmbxEmpleado.IsEnabled = habilitada;
            btnAgregarProducto.IsEnabled = habilitada;
            btnQuitarProducto.IsEnabled = habilitada;
            dtgProductos.IsEnabled = habilitada;
        }

        private void btnRegresar_Click(object sender, RoutedEventArgs e)
        {
            VentanaVentas pagina = new VentanaVentas();
            pagina.Show();
            this.Close();
        }

        private void btnNuevaVenta_Click(object sender, RoutedEventArgs e)
        {
            LimparCajas();
            HabilitarCajasYCombos(true);
            HabiltarBotones(true);
            ActualizarCombos();
            tiked = new Tiked();
            tiked.ProductosComprados = new List<Productos>();
            ActulizarTablaDeProductosAhComprar();
            suma = 0;
            accionvale = accion.nuevo;
        }

        private void ActulizarTablaDeProductosAhComprar()
        {
            dtgProductos.ItemsSource = null;
            dtgProductos.ItemsSource = tiked.ProductosComprados;

        }

        private void btnCancelarVenta_Click(object sender, RoutedEventArgs e)
        {
            LimparCajas();
            HabilitarCajasYCombos(false);
            HabiltarBotones(false);
        }

        private void btnAgregarProducto_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbxCantidadDelProducto.Text))
            {
                MessageBox.Show("Te ha faltado ingresar la cantidad", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                tbxCantidadDelProducto.Clear();
            }
            else
            {
                Productos productos = cmbxProducto.SelectedItem as Productos;
                if (productos != null)
                {
                    try
                    {
                        float venta = 0;
                        int cantidad = int.Parse(tbxCantidadDelProducto.Text);
                        int stok = productos.cantidad;
                        if (stok == 0)
                        {
                            MessageBox.Show("Error no hay articulos en existencia", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                        else
                        {
                            if (cantidad > stok)
                            {
                                MessageBox.Show("Error no hay suficientes articulos en existencia", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                            }
                            else
                            {
                                venta = productos.PrecioVenta * cantidad;
                                productos.cantidad = cantidad;
                                tiked.ProductosComprados.Add(productos);
                                ActulizarTablaDeProductosAhComprar();
                                suma += venta;
                                txblkTotalAPagar.Text = suma.ToString();
                                productos.cantidad = stok - cantidad;
                            }
                        }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("" + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                }
            

            }
            
        }

        private void btnQuitarProducto_Click(object sender, RoutedEventArgs e)
        {
            Productos productos = dtgProductos.SelectedItem as Productos;
            if (productos != null)
            {
                try
                {
                    float venta = 0;
                    //int cantidad = int.Parse(tbxCantidadDelProducto.Text);
                    int stok = productos.cantidad;

                        venta = productos.PrecioVenta * stok;
                        
                        tiked.ProductosComprados.Remove(productos);
                        ActulizarTablaDeProductosAhComprar();
                        suma -= venta;
                        txblkTotalAPagar.Text = suma.ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("" + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
        }
    }
}
