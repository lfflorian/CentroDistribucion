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
    /// Lógica de interacción para Distribucions.xaml
    /// </summary>
    public partial class Distribuciones : Page
    {
        Administrador.Administrador admin;
        Distribucion DistribucionSeleccionado;
        /**/
        List<Producto> ListProducto;
        public Distribuciones()
        {
            InitializeComponent();
            admin = new Administrador.Administrador();
            DistribucionSeleccionado = new Distribucion();
            ListProducto = new List<Producto>();
            FillTablaDatos();
        }

        public void FillTablaDatos()
        {
            TablaDatos.Items.Clear();
            try
            {
                var Distribucions = admin.Retornar("Distribucion");
                Distribucions.ForEach(x => {
                    try
                    {
                        var json = JsonConvert.SerializeObject(x);
                        var dist = JsonConvert.DeserializeObject<Distribucion>(json);
                        TablaDatos.Items.Add(dist);
                    }
                    catch (Exception)
                    {
                    }
                });

                LlenarCombobox();
            }
            catch (Exception)
            {

                throw;
            }
        }
        
        public void VaciarControles()
        {
            DistribucionSeleccionado = new Distribucion();
            txtId.Text = "";
            txtCantidad.Text = "";
            cmbProducto.Text = "";
            cmbSupermercado.Text = "";
            btnGuardar.IsEnabled = false;
            txtId.IsEnabled = false;
        }

        public void GetData()
        {
            try
            {
                DistribucionSeleccionado.Id = Convert.ToInt32(txtId.Text);
                DistribucionSeleccionado.Cantidad = Convert.ToInt32(txtCantidad.Text);
                DistribucionSeleccionado.IdProducto = cmbProducto.Text;
                DistribucionSeleccionado.IdSupermercado = cmbSupermercado.Text;

                var precioTemp = ListProducto.Find(x => x.Nombre == DistribucionSeleccionado.IdProducto).Precio;
                DistribucionSeleccionado.Total = DistribucionSeleccionado.Cantidad * precioTemp;

            }
            catch (Exception)
            {

            }
        }

        public void LlenarCombobox()
        {
            cmbProducto.Items.Clear();
            cmbSupermercado.Items.Clear();
            try
            {
                var productos = admin.Retornar("Producto");
                var supermercados = admin.Retornar("Supermercado");
                productos.ForEach(x => {
                    try
                    {
                        var json = JsonConvert.SerializeObject(x);
                        var producto = JsonConvert.DeserializeObject<Producto>(json);
                        cmbProducto.Items.Add(producto.Nombre);
                        ListProducto.Add(producto);
                    }
                    catch (Exception)
                    {
                    }
                });

                supermercados.ForEach(x => {
                    try
                    {
                        var json = JsonConvert.SerializeObject(x);
                        var supermercado = JsonConvert.DeserializeObject<Supermercado>(json);
                        cmbSupermercado.Items.Add(supermercado.Nombre);
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

        private void TablaDatos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                btnGuardar.IsEnabled = false;
                txtId.IsEnabled = false;
                var objeto = TablaDatos.SelectedItem;
                DistribucionSeleccionado = (Distribucion)objeto;
                cmbProducto.Text = DistribucionSeleccionado.IdProducto;
                cmbSupermercado.Text = DistribucionSeleccionado.IdSupermercado;
                txtCantidad.Text = DistribucionSeleccionado.Cantidad.ToString();
                txtId.Text = DistribucionSeleccionado.Id.ToString();
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
            admin.Actualizar(DistribucionSeleccionado, "IdDistribucion");
            FillTablaDatos();
            VaciarControles();
        }
        
        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            admin.Eliminar(DistribucionSeleccionado);
            FillTablaDatos();
            VaciarControles();
        }

        private void btnCrear_Click(object sender, RoutedEventArgs e)
        {
            txtCantidad.Text = "";
            txtId.Text = "";
            cmbProducto.Text = "";
            cmbSupermercado.Text = "";
            btnGuardar.IsEnabled = true;
            txtId.IsEnabled = true;
        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            GetData();
            admin.Crear(DistribucionSeleccionado);
            FillTablaDatos();
            VaciarControles();
        }
    }
}
