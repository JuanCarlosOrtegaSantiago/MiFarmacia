using MiFarmacia.BIZ;
using MiFarmacia.COMMON.Entidades;
using MiFarmacia.COMMON.Interfaces;
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
    /// Lógica de interacción para VentanaTablas.xaml
    /// </summary>
    public partial class VentanaTablas : Window
    {
        enum accion
        {
            nuevo,
            editar
        }
        accion accionDeEmpleados;
        accion accionDeClientes;
        accion AccionDeProcuctos;


        IManejadorEmpleados manejadorEmpleados;
        IManejadorCliente manejadorCliente;
        IManejadorProductos manejadorProductos;


        public VentanaTablas()
        {
            InitializeComponent();

            manejadorEmpleados = new ManejadorEmpleados(new EmpleadoRepositorio());
            manejadorCliente = new ManejadorClientes(new ClienteRepositorio());
            manejadorProductos = new ManejadorProductos(new ProductoRepositorios());

            PonerBotonesDeEdicionProductos(false);
            PonerBotonesDeEdicionCliente(false);
            PonerBotonesDeEdicionEmpleado(false);

            LimpiarCajasProductos();
            LimpiarCajasCliente();
            LimpiarCajasEmpleados();

            HabilitarCajasProductos(false);
            HabilitarCajasCliente(false);
            HabilitarCajasEmpleados(false);

            ActualizarTablaProductos();
            ActualizarTablaClientes();
            ActualizarTablaEmpleados();

        }

        private void ActualizarTablaProductos()
        {
            dtgProductos.ItemsSource = null;
            dtgProductos.ItemsSource = manejadorProductos.Listar;
        }

        private void HabilitarCajasProductos(bool habilitada)
        {
            tbxCantidadProductos.IsEnabled=habilitada;
            tbxCategoriaProductos.IsEnabled = habilitada;
            tbxDescripcionProductos.IsEnabled = habilitada;
            tbxNombreProductos.IsEnabled = habilitada;
            tbxPresentacionProductos.IsEnabled = habilitada;
            tbxPresioCompraProductos.IsEnabled = habilitada;
            tbxPresioVentaProductos.IsEnabled = habilitada;
        }

        private void LimpiarCajasProductos()
        {
            tbxblkIDProductos.Text = "";
            tbxCantidadProductos.Clear();
            tbxCategoriaProductos.Clear();
            tbxDescripcionProductos.Clear();
            tbxNombreProductos.Clear();
            tbxPresentacionProductos.Clear();
            tbxPresioCompraProductos.Clear();
            tbxPresioVentaProductos.Clear();
        }

        private void PonerBotonesDeEdicionProductos(bool habilitado)
        {
            btnAgregarProductos.IsEnabled = !habilitado;
            btnCancelarProductos.IsEnabled = habilitado;
            btnEditarProductos.IsEnabled = !habilitado;
            btnEliminarProductos.IsEnabled = !habilitado;
            btnGuardarProductos.IsEnabled = habilitado;
        }

        private void ActualizarTablaClientes()
        {
            dtgClientes.ItemsSource = null;
            dtgClientes.ItemsSource = manejadorCliente.Listar;
        }

        private void HabilitarCajasCliente(bool habilitada)
        {
            tbxDireccionCliente.IsEnabled = habilitada;
            tbxNombreCliente.IsEnabled = habilitada;
            tbxCorreoCliente.IsEnabled = habilitada;
            tbxTelefonoCliente.IsEnabled = habilitada;
            tbxRFcCliente.IsEnabled = habilitada;
        }

        private void LimpiarCajasCliente()
        {
            tbxblkIDClientes.Text = "";
            tbxDireccionCliente.Clear();
            tbxNombreCliente.Clear();
            tbxRFcCliente.Clear();
            tbxTelefonoCliente.Clear();
            tbxCorreoCliente.Clear();
        }

        private void PonerBotonesDeEdicionCliente(bool habilitado)
        {
            btnAgregarCliente.IsEnabled = !habilitado;
            btnCancelarCliente.IsEnabled = habilitado;
            btnEditarCliente.IsEnabled = !habilitado;
            btnEliminarCliente.IsEnabled = !habilitado;
            btnGuardarCliente.IsEnabled = habilitado;
        }

        private void ActualizarTablaEmpleados()
        {
            dtgEmpleados.ItemsSource = null;
            dtgEmpleados.ItemsSource = manejadorEmpleados.Listar;
        }

        private void HabilitarCajasEmpleados(bool habilitada)
        {
            tbxDireccionEmpleado.IsEnabled = habilitada;
            tbxNombreEmpleado.IsEnabled = habilitada;
            tbxPuestoEmpleado.IsEnabled = habilitada;
            tbxTelefonoEmpleado.IsEnabled = habilitada;
        }

        private void LimpiarCajasEmpleados()
        {
            tbxblkIDEmpleado.Text = "";
            tbxDireccionEmpleado.Clear();
            tbxNombreEmpleado.Clear();
            tbxPuestoEmpleado.Clear();
            tbxTelefonoEmpleado.Clear();
        }

        private void PonerBotonesDeEdicionEmpleado(bool habilitado)
        {
            btnAgregarEmpleado.IsEnabled = !habilitado;
            btnCancelarEmpleado.IsEnabled = habilitado;
            btnEditarEmpleado.IsEnabled = !habilitado;
            btnEliminarEmpleado.IsEnabled = !habilitado;
            btnGuardarEmpleado.IsEnabled = habilitado;
        }

        private void btnAgregarEmpleado_Click(object sender, RoutedEventArgs e)
        {
            LimpiarCajasEmpleados();
            HabilitarCajasEmpleados(true);
            PonerBotonesDeEdicionEmpleado(true);
            accionDeEmpleados = accion.nuevo;
        }

        private void btnEditarEmpleado_Click(object sender, RoutedEventArgs e)
        {
            if (manejadorEmpleados.Listar.Count() == 0)
            {
                MessageBox.Show("No tienes ningun empleado\npara editar", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                Empleado emple = dtgEmpleados.SelectedItem as Empleado;
                if (emple != null)
                {
                    LimpiarCajasEmpleados();
                    HabilitarCajasEmpleados(true);
                    PonerBotonesDeEdicionEmpleado(true);

                    tbxblkIDEmpleado.Text = emple.Id;
                    tbxDireccionEmpleado.Text = emple.direccion;
                    tbxNombreEmpleado.Text = emple.nombre;
                    tbxPuestoEmpleado.Text = emple.puesto;
                    tbxTelefonoEmpleado.Text = emple.telefono;

                    accionDeEmpleados = accion.editar;
                }
            }
        }

        private void btnEliminarEmpleado_Click(object sender, RoutedEventArgs e)
        {

            if (manejadorEmpleados.Listar.Count() == 0)
            {
                MessageBox.Show("No tienes ningun empleado\npara eliminar", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                Empleado emple = dtgEmpleados.SelectedItem as Empleado;
                if (emple != null)
                {
                    if (MessageBox.Show("Realmente deceas eliminar al empleado:" + emple.nombre, "Eliminar", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                    {
                        if (manejadorEmpleados.Eliminar(emple.Id))
                        {
                            MessageBox.Show("El empleado ha sido eliminado", "Empleado Eliminado", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                            ActualizarTablaEmpleados();
                        }
                        else
                        {
                            MessageBox.Show("No pudo ser elimiado el empleado", "Error", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                        }
                    }
                }
            }
            
        }

        private void btnCancelarEmpleado_Click(object sender, RoutedEventArgs e)
        {
            LimpiarCajasEmpleados();
            HabilitarCajasEmpleados(false);
            PonerBotonesDeEdicionEmpleado(false);
        }

        private void btnGuardarEmpleado_Click(object sender, RoutedEventArgs e)
        {
            if (accionDeEmpleados == accion.nuevo)
            {
                if (string.IsNullOrWhiteSpace(tbxDireccionEmpleado.Text) || string.IsNullOrWhiteSpace(tbxNombreEmpleado.Text) || string.IsNullOrWhiteSpace(tbxPuestoEmpleado.Text) || string.IsNullOrWhiteSpace(tbxTelefonoEmpleado.Text))
                {
                    MessageBox.Show("Faltan datos por llenar ", "Error", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                }
                else
                {
                    Empleado emple = new Empleado()
                    {
                        direccion = tbxDireccionEmpleado.Text,
                        nombre = tbxNombreEmpleado.Text,
                        puesto = tbxPuestoEmpleado.Text,
                        telefono = tbxTelefonoEmpleado.Text
                    };
                    if (manejadorEmpleados.agregar(emple))
                    {
                        MessageBox.Show("Se agregó un nuevo empleado: " + emple.nombre, "Empleado agregado", MessageBoxButton.OK, MessageBoxImage.Information);
                        LimpiarCajasEmpleados();
                        HabilitarCajasEmpleados(false);
                        PonerBotonesDeEdicionEmpleado(false);
                        ActualizarTablaEmpleados();
                    }
                    else
                    {
                        MessageBox.Show("No pudo ser agregado el empleado: " + emple.nombre, "Error", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                    }
                }
            }
            else
            {
                if (string.IsNullOrWhiteSpace(tbxDireccionEmpleado.Text) || string.IsNullOrWhiteSpace(tbxNombreEmpleado.Text) || string.IsNullOrWhiteSpace(tbxPuestoEmpleado.Text) || string.IsNullOrWhiteSpace(tbxTelefonoEmpleado.Text))
                {
                    MessageBox.Show("Faltan datos por llenar ", "Error", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                }
                else
                {
                    Empleado emple = dtgEmpleados.SelectedItem as Empleado;
                    emple.direccion = tbxDireccionEmpleado.Text;
                    emple.nombre = tbxNombreEmpleado.Text;
                    emple.puesto = tbxPuestoEmpleado.Text;
                    emple.telefono = tbxTelefonoEmpleado.Text;
                    if (manejadorEmpleados.Modificar(emple))
                    {
                        MessageBox.Show("Se modifico el empleado correctamente", "Empleado Modificado", MessageBoxButton.OK, MessageBoxImage.Information);
                        LimpiarCajasEmpleados();
                        HabilitarCajasEmpleados(false);
                        PonerBotonesDeEdicionEmpleado(false);
                        ActualizarTablaEmpleados();
                    }
                    else
                    {
                        MessageBox.Show("No pudo ser modificado el empleado: ", "Error", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                    }
                }
            }
        }

        private void btnAgregarCliente_Click(object sender, RoutedEventArgs e)
        {
            LimpiarCajasCliente();
            HabilitarCajasCliente(true);
            PonerBotonesDeEdicionCliente(true);
            accionDeClientes = accion.nuevo;
        }

        private void btnEditarCliente_Click(object sender, RoutedEventArgs e)
        {
            if (manejadorCliente.Listar.Count() == 0)
            {
                MessageBox.Show("No tienes ningun clieente\npara editar", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                Cliente cliente = dtgClientes.SelectedItem as Cliente;
                if (cliente != null)
                {
                    LimpiarCajasCliente();
                    HabilitarCajasCliente(true);
                    PonerBotonesDeEdicionCliente(true);

                    tbxblkIDClientes.Text = cliente.Id;
                    tbxCorreoCliente.Text = cliente.Correo;
                    tbxDireccionCliente.Text = cliente.direccion;
                    tbxNombreCliente.Text = cliente.nombre;
                    tbxRFcCliente.Text = cliente.RFC;
                    tbxTelefonoCliente.Text = cliente.telefono;

                    accionDeClientes = accion.editar;
                }
            }

        }

        private void btnEliminarCliente_Click(object sender, RoutedEventArgs e)
        {
            if (manejadorCliente.Listar.Count() == 0)
            {
                MessageBox.Show("No tienes ningun clieente\npara eliminar", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                Cliente cliente= dtgClientes.SelectedItem as Cliente;
                if (cliente != null)
                {
                    if (MessageBox.Show("Realmente deceas eliminar al cliente:" + cliente.nombre, "Eliminar", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                    {
                        if (manejadorCliente.Eliminar(cliente.Id))
                        {
                            MessageBox.Show("El cliente ha sido eliminado", "cliente Eliminado", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                            ActualizarTablaClientes();
                        }
                        else
                        {
                            MessageBox.Show("No pudo ser elimiado el cliente", "Error", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                        }
                    }
                }
            }

            
        }

        private void btnCancelarCliente_Click(object sender, RoutedEventArgs e)
        {
            LimpiarCajasCliente();
            HabilitarCajasCliente(false);
            PonerBotonesDeEdicionCliente(false);
        }

        private void btnGuardarCliente_Click(object sender, RoutedEventArgs e)
        {
            if(accionDeClientes == accion.nuevo)
            {
                if (string.IsNullOrWhiteSpace(tbxCorreoCliente.Text) || string.IsNullOrWhiteSpace(tbxDireccionCliente.Text) || string.IsNullOrWhiteSpace(tbxNombreCliente.Text) || string.IsNullOrWhiteSpace(tbxRFcCliente.Text) || string.IsNullOrWhiteSpace(tbxTelefonoCliente.Text))
                {
                    MessageBox.Show("Faltan datos por llenar ", "Error", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                }
                else
                {
                    Cliente cliente = new Cliente()
                    {
                        Correo = tbxCorreoCliente.Text,
                        direccion = tbxDireccionCliente.Text,
                        nombre = tbxNombreCliente.Text,
                        RFC = tbxRFcCliente.Text,
                        telefono = tbxTelefonoCliente.Text
                    };
                    if (manejadorCliente.agregar(cliente))
                    {
                        MessageBox.Show("Se agregó un nuevo cliente", "Cliente agregado", MessageBoxButton.OK, MessageBoxImage.Information);
                        LimpiarCajasCliente();
                        HabilitarCajasCliente(false);
                        PonerBotonesDeEdicionCliente(false);
                        ActualizarTablaClientes();
                    }
                    else
                    {
                        MessageBox.Show("No pudo ser agregado el cliente", "Error", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                    }
                }
            }
            else
            {
                if (string.IsNullOrWhiteSpace(tbxCorreoCliente.Text) || string.IsNullOrWhiteSpace(tbxDireccionCliente.Text) || string.IsNullOrWhiteSpace(tbxNombreCliente.Text) || string.IsNullOrWhiteSpace(tbxRFcCliente.Text) || string.IsNullOrWhiteSpace(tbxTelefonoCliente.Text))
                {
                    MessageBox.Show("Faltan datos por llenar ", "Error", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                }
                else
                {
                    Cliente cliente = dtgClientes.SelectedItem as Cliente;
                    cliente.Correo = tbxCorreoCliente.Text;
                    cliente.direccion = tbxDireccionCliente.Text;
                    cliente.nombre = tbxNombreCliente.Text;
                    cliente.RFC = tbxRFcCliente.Text;
                    cliente.telefono = tbxTelefonoCliente.Text;
                    if (manejadorCliente.Modificar(cliente))
                    {
                        MessageBox.Show("Se modifico el cliente correctamente", "Cliente Modificado", MessageBoxButton.OK, MessageBoxImage.Information);
                        LimpiarCajasCliente();
                        HabilitarCajasCliente(false);
                        PonerBotonesDeEdicionCliente(false);
                        ActualizarTablaClientes();
                    }
                    else
                    {
                        MessageBox.Show("No pudo ser modificado el cliente ", "Error", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                    }
                }
            }

        }

        private void btnAgregarProductos_Click(object sender, RoutedEventArgs e)
        {
            LimpiarCajasProductos();
            HabilitarCajasProductos(true);
            PonerBotonesDeEdicionProductos(true);
            AccionDeProcuctos = accion.nuevo;
        }

        private void btnEditarProductos_Click(object sender, RoutedEventArgs e)
        {
            if (manejadorProductos.Listar.Count() == 0)
            {
                MessageBox.Show("No tienes ningun Producto\npara editar", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                Productos productos = dtgProductos.SelectedItem as Productos;
                if (productos != null)
                {
                    LimpiarCajasProductos();
                    HabilitarCajasProductos(true);
                    PonerBotonesDeEdicionProductos(true);

                    tbxblkIDProductos.Text = productos.Id;
                    tbxCantidadProductos.Text = productos.cantidad.ToString();
                    tbxCategoriaProductos.Text = productos.categoria;
                    tbxNombreProductos.Text = productos.nombreDelProducto;
                    tbxDescripcionProductos.Text = productos.descripcion;
                    tbxPresioCompraProductos.Text = productos.PrecioCompra.ToString();
                    tbxPresioVentaProductos.Text = productos.PrecioVenta.ToString();
                    tbxPresentacionProductos.Text = productos.presentacion;

                    AccionDeProcuctos = accion.editar;
                }
            }
        }

        private void btnEliminarProductos_Click(object sender, RoutedEventArgs e)
        {
            if (manejadorProductos.Listar.Count() == 0)
            {
                MessageBox.Show("No tienes ningun Producto\npara eliminar", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                Productos productos = dtgProductos.SelectedItem as Productos;
                if (productos != null)
                {
                    if (MessageBox.Show("Realmente deceas eliminar el producto:" + productos.nombreDelProducto, "Eliminar", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                    {
                        if (manejadorProductos.Eliminar(productos.Id))
                        {
                            MessageBox.Show("El producto ha sido eliminado", "Producto Eliminado", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                            ActualizarTablaProductos();
                        }
                        else
                        {
                            MessageBox.Show("No pudo ser elimiado el producto", "Error", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                        }
                    }
                }
            }
        }

        private void btnCancelarProductos_Click(object sender, RoutedEventArgs e)
        {
            LimpiarCajasProductos();
            HabilitarCajasProductos(false);
            PonerBotonesDeEdicionProductos(false);
        }

        private void btnGuardarProductos_Click(object sender, RoutedEventArgs e)
        {
            if (AccionDeProcuctos == accion.nuevo)
            {
                if (string.IsNullOrWhiteSpace(tbxCantidadProductos.Text) || string.IsNullOrWhiteSpace(tbxCategoriaProductos.Text) || string.IsNullOrWhiteSpace(tbxNombreProductos.Text) || string.IsNullOrWhiteSpace(tbxDescripcionProductos.Text) || string.IsNullOrWhiteSpace(tbxPresioCompraProductos.Text) || string.IsNullOrWhiteSpace(tbxPresioVentaProductos.Text) || string.IsNullOrWhiteSpace(tbxPresentacionProductos.Text))
                {
                    MessageBox.Show("Faltan datos por llenar ", "Error", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                }
                else
                {
                    try
                    {
                        Productos productos = new Productos()
                        {
                            cantidad = int.Parse(tbxCantidadProductos.Text),
                            categoria = tbxCategoriaProductos.Text,
                            descripcion = tbxDescripcionProductos.Text,
                            nombreDelProducto = tbxNombreProductos.Text,
                            PrecioCompra = float.Parse(tbxPresioCompraProductos.Text),
                            PrecioVenta = float.Parse(tbxPresioVentaProductos.Text),
                            presentacion = tbxPresentacionProductos.Text
                        };
                        if (manejadorProductos.agregar(productos))
                        {
                            MessageBox.Show("Se agregó un nuevo producto", "Producto agregado", MessageBoxButton.OK, MessageBoxImage.Information);
                            LimpiarCajasProductos();
                            HabilitarCajasProductos(false);
                            PonerBotonesDeEdicionProductos(false);
                            ActualizarTablaProductos();
                        }
                        else
                        {
                            MessageBox.Show("No pudo ser agregado el producto", "Error", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                        }
                    }
                    catch (Exception ex )
                    {
                        MessageBox.Show("Error:\n"+ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    
                }
            }
            else
            {
                if (string.IsNullOrWhiteSpace(tbxCantidadProductos.Text) || string.IsNullOrWhiteSpace(tbxCategoriaProductos.Text) || string.IsNullOrWhiteSpace(tbxNombreProductos.Text) || string.IsNullOrWhiteSpace(tbxDescripcionProductos.Text) || string.IsNullOrWhiteSpace(tbxPresioCompraProductos.Text) || string.IsNullOrWhiteSpace(tbxPresioVentaProductos.Text) || string.IsNullOrWhiteSpace(tbxPresentacionProductos.Text))
                {
                    MessageBox.Show("Faltan datos por llenar ", "Error", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                }
                else
                {
                    Productos productos = dtgProductos.SelectedItem as Productos;

                    productos.cantidad = int.Parse(tbxCantidadProductos.Text);
                    productos.categoria = tbxCategoriaProductos.Text;
                    productos.descripcion = tbxDescripcionProductos.Text;
                    productos.nombreDelProducto = tbxNombreProductos.Text;
                    productos.PrecioCompra = float.Parse(tbxPresioCompraProductos.Text);
                    productos.PrecioVenta = float.Parse(tbxPresioVentaProductos.Text);
                    productos.presentacion = tbxPresentacionProductos.Text;

                    if (manejadorProductos.Modificar(productos))
                    {
                        MessageBox.Show("Se modifico el producto", "Producto modificado", MessageBoxButton.OK, MessageBoxImage.Information);
                        LimpiarCajasProductos();
                        HabilitarCajasProductos(false);
                        PonerBotonesDeEdicionProductos(false);
                        ActualizarTablaProductos();
                    }
                    else
                    {
                        MessageBox.Show("No pudo ser agregado el producto", "Error", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                    }
                }
            }
        }

        private void btnRegresar_Click(object sender, RoutedEventArgs e)
        {
            MainWindow pagina = new MainWindow();
            pagina.Show();
            this.Close();
        }
    }
}
