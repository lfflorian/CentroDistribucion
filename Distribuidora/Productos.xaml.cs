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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Administrador;
using Distribuidora.Model;
using Newtonsoft.Json;

namespace Distribuidora
{
    /// <summary>
    /// Lógica de interacción para Usuarios.xaml
    /// </summary>
    public partial class Productos : Page
    {
        Administrador.Administrador admin;
        Producto productoSeleccionado;
        public Productos()
        {
            InitializeComponent();
            admin = new Administrador.Administrador();
            productoSeleccionado = new Producto();
            FillTablaDatos();
        }

        public void FillTablaDatos()
        {
            TablaDatos.Items.Clear();
            try
            {
                var usuarios = admin.Retornar("Producto");
                usuarios.ForEach(x => {
                    try
                    {
                        var json = JsonConvert.SerializeObject(x);
                        var product = JsonConvert.DeserializeObject<Producto>(json);
                        TablaDatos.Items.Add(product);
                    }
                    catch (Exception)
                    {
                    }
                });
            }
            catch (Exception)
            {

                throw;
            }
        }
        
        public void VaciarControles()
        {
            productoSeleccionado = new Producto();
            txtNombre.Text = "";
            txtId.Text = "";
            txtDescripcion.Text = "";
            txtPrecio.Text = "";
            btnGuardar.IsEnabled = false;
            txtId.IsEnabled = false;
        }

        public void GetData()
        {
            try
            {
                productoSeleccionado.Nombre = txtNombre.Text;
                productoSeleccionado.Id = Convert.ToInt32(txtId.Text);
                productoSeleccionado.Descripcion = txtDescripcion.Text;
                productoSeleccionado.Precio = Convert.ToDecimal(txtPrecio.Text);
            }
            catch (Exception)
            {

            }
        }

        private void TablaDatos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                btnGuardar.IsEnabled = false;
                txtId.IsEnabled = false;
                var objeto = TablaDatos.SelectedItem;
                productoSeleccionado = (Producto)objeto;
                txtNombre.Text = productoSeleccionado.Nombre;
                txtId.Text = productoSeleccionado.Id.ToString();
                txtDescripcion.Text = productoSeleccionado.Descripcion;
                txtPrecio.Text = productoSeleccionado.Precio.ToString();
            }
            catch (Exception)
            {
            }
        }

        private void btnRefrescar_Click(object sender, RoutedEventArgs e)
        {
            FillTablaDatos();
            VaciarControles();
        }

        private void btnActualizar_Click(object sender, RoutedEventArgs e)
        {
            GetData();
            admin.Actualizar(productoSeleccionado, "IdUsuario");
            FillTablaDatos();
            VaciarControles();
        }
        
        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            admin.Eliminar(productoSeleccionado);
            FillTablaDatos();
            VaciarControles();
        }

        private void btnCrear_Click(object sender, RoutedEventArgs e)
        {
            txtNombre.Text = "";
            txtId.Text = "";
            txtDescripcion.Text = "";
            txtPrecio.Text = "";
            btnGuardar.IsEnabled = true;
            txtId.IsEnabled = true;
        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            GetData();
            admin.Crear(productoSeleccionado);
            FillTablaDatos();
            VaciarControles();
        }
    }
}
