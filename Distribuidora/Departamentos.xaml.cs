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
    public partial class Departamentos : Page
    {
        Administrador.Administrador admin;
        Departamento departamentoSeleccionado;
        public Departamentos()
        {
            InitializeComponent();
            admin = new Administrador.Administrador();
            departamentoSeleccionado = new Departamento();
            FillTablaDatos();
        }

        public void FillTablaDatos()
        {
            TablaDatos.Items.Clear();
            try
            {
                var usuarios = admin.Retornar("Departamento");
                usuarios.ForEach(x => {
                    try
                    {
                        var json = JsonConvert.SerializeObject(x);
                        var department = JsonConvert.DeserializeObject<Departamento>(json);
                        TablaDatos.Items.Add(department);
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
            departamentoSeleccionado = new Departamento();
            txtNombre.Text = "";
            txtId.Text = "";
            btnGuardar.IsEnabled = false;
            txtId.IsEnabled = false;
        }

        public void GetData()
        {
            try
            {
                departamentoSeleccionado.Nombre = txtNombre.Text;
                departamentoSeleccionado.Id = Convert.ToInt32(txtId.Text);
            }
            catch (Exception es)
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
                departamentoSeleccionado = (Departamento)objeto;
                txtNombre.Text = departamentoSeleccionado.Nombre;
                txtId.Text = departamentoSeleccionado.Id.ToString();
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
            admin.Actualizar(departamentoSeleccionado, "Id");
            FillTablaDatos();
            VaciarControles();
        }
        
        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            admin.Eliminar(departamentoSeleccionado);
            FillTablaDatos();
            VaciarControles();
        }

        private void btnCrear_Click(object sender, RoutedEventArgs e)
        {
            txtNombre.Text = "";
            txtId.Text = "";
            btnGuardar.IsEnabled = true;
            txtId.IsEnabled = true;
        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            GetData();
            admin.Crear(departamentoSeleccionado);
            FillTablaDatos();
            VaciarControles();
        }
    }
}
