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
    public partial class Usuarios : Page
    {
        Administrador.Administrador admin;
        Usuario usuarioSeleccionado;
        public Usuarios()
        {
            InitializeComponent();
            admin = new Administrador.Administrador();
            usuarioSeleccionado = new Usuario();
            FillTablaDatos();
        }

        public void FillTablaDatos()
        {
            TablaDatos.Items.Clear();
            try
            {
                var usuarios = admin.Retornar("Usuario");
                usuarios.ForEach(x => {
                    try
                    {
                        var json = JsonConvert.SerializeObject(x);
                        var user = JsonConvert.DeserializeObject<Usuario>(json);
                        TablaDatos.Items.Add(user);
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
            usuarioSeleccionado = new Usuario();
            txtNombre.Text = "";
            txtId.Text = "";
            txtContraseña.Text = "";
            cmbRol.Text = "";
            btnGuardar.IsEnabled = false;
            txtId.IsEnabled = false;
        }

        public void GetData()
        {
            try
            {
                usuarioSeleccionado.Nombre = txtNombre.Text;
                usuarioSeleccionado.IdUsuario = txtId.Text;
                usuarioSeleccionado.Contraseña = txtContraseña.Text;
                usuarioSeleccionado.Rol = Convert.ToInt32(cmbRol.Text);
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
                usuarioSeleccionado = (Usuario)objeto;
                txtNombre.Text = usuarioSeleccionado.Nombre;
                txtId.Text = usuarioSeleccionado.IdUsuario;
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
            admin.Actualizar(usuarioSeleccionado, "IdUsuario");
            FillTablaDatos();
            VaciarControles();
        }
        
        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            admin.Eliminar(usuarioSeleccionado);
            FillTablaDatos();
            VaciarControles();
        }

        private void btnCrear_Click(object sender, RoutedEventArgs e)
        {
            txtNombre.Text = "";
            txtId.Text = "";
            txtContraseña.Text = "";
            cmbRol.Text = "";
            btnGuardar.IsEnabled = true;
            txtId.IsEnabled = true;
        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            GetData();
            admin.Crear(usuarioSeleccionado);
            FillTablaDatos();
            VaciarControles();
        }
    }
}
