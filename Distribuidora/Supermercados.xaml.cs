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
    public partial class Supermercados : Page
    {
        Administrador.Administrador admin;
        Supermercado superMercadoSeleccionado;
        public Supermercados()
        {
            InitializeComponent();
            admin = new Administrador.Administrador();
            superMercadoSeleccionado = new Supermercado();
            FillTablaDatos();
        }

        public void FillTablaDatos()
        {
            TablaDatos.Items.Clear();
            try
            {
                var usuarios = admin.Retornar("Supermercado");
                usuarios.ForEach(x => {
                    try
                    {
                        var json = JsonConvert.SerializeObject(x);
                        var market = JsonConvert.DeserializeObject<Supermercado>(json);
                        TablaDatos.Items.Add(market);
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
            superMercadoSeleccionado = new Supermercado();
            txtNombre.Text = "";
            txtId.Text = "";
            txtDireccion.Text = "";
            txtTelefono.Text = "";
            btnGuardar.IsEnabled = false;
            txtId.IsEnabled = false;
        }

        public void GetData()
        {
            try
            {
                superMercadoSeleccionado.Nombre = txtNombre.Text;
                superMercadoSeleccionado.Id = Convert.ToInt32(txtId.Text);
                superMercadoSeleccionado.Direccion = txtDireccion.Text;
                superMercadoSeleccionado.Telefono = txtTelefono.Text;
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
                superMercadoSeleccionado = (Supermercado)objeto;
                txtNombre.Text = superMercadoSeleccionado.Nombre;
                txtId.Text = superMercadoSeleccionado.Id.ToString();
                txtDireccion.Text = superMercadoSeleccionado.Direccion;
                txtTelefono.Text = superMercadoSeleccionado.Telefono;
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
            admin.Actualizar(superMercadoSeleccionado, "IdUsuario");
            FillTablaDatos();
            VaciarControles();
        }
        
        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            admin.Eliminar(superMercadoSeleccionado);
            FillTablaDatos();
            VaciarControles();
        }

        private void btnCrear_Click(object sender, RoutedEventArgs e)
        {
            txtNombre.Text = "";
            txtId.Text = "";
            txtDireccion.Text = "";
            txtTelefono.Text = "";
            btnGuardar.IsEnabled = true;
            txtId.IsEnabled = true;
        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            GetData();
            admin.Crear(superMercadoSeleccionado);
            FillTablaDatos();
            VaciarControles();
        }
    }
}
