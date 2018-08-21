using Distribuidora.Model;
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

namespace Distribuidora
{
    /// <summary>
    /// Lógica de interacción para ControlDistribuciones.xaml
    /// </summary>
    public partial class ControlDistribuciones : Window
    {
        Usuario usuarioRecibido;
        public ControlDistribuciones(Usuario user)
        {
            usuarioRecibido = user;
            InitializeComponent();
            OpcionesDisponibles();
        }

        private void Sailr_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        
        public void OpcionesDisponibles()
        {
            var rol = usuarioRecibido.Rol;
            if (rol == 2)
            {
                administracionModulo.Visibility = Visibility.Collapsed;
            } else if (rol == 3)
            {
                administracionModulo.Visibility = Visibility.Collapsed;
            }
        }

        private void opSupermercado_Click(object sender, RoutedEventArgs e)
        {
            Supermercados u = new Supermercados();
            Mostrar.Navigate(u);
        }

        private void opProductos_Click(object sender, RoutedEventArgs e)
        {
            Productos u = new Productos();
            Mostrar.Navigate(u);
        }

        private void opDistribucion_Click(object sender, RoutedEventArgs e)
        {
            Distribuciones u = new Distribuciones();
            Mostrar.Navigate(u);
        }

        private void opUsuario_Click(object sender, RoutedEventArgs e)
        {
            Usuarios u = new Usuarios();
            Mostrar.Navigate(u);
        }

        private void opDepartamento_Click(object sender, RoutedEventArgs e)
        {
            Departamentos u = new Departamentos();
            Mostrar.Navigate(u);
        }
    }
}
