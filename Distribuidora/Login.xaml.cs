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
using Administrador;
using Distribuidora.Model;
using Newtonsoft.Json;

namespace Distribuidora
{
    /// <summary>
    /// Lógica de interacción para Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        Administrador.Administrador admin;
        public Login()
        {
            InitializeComponent();
            admin = new Administrador.Administrador();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var resultado = admin.Buscar(txtUsuario.Text, "IdUsuario", "Usuario");
            if (resultado != null)
            {
                var json = JsonConvert.SerializeObject(resultado);
                var user = JsonConvert.DeserializeObject<Usuario>(json);

                if (user.Contraseña == txtContraseña.Text)
                {
                    ControlDistribuciones Cd = new ControlDistribuciones(user);
                    Cd.Show();
                }
                else
                {
                    MessageBox.Show("Contraseña Incorrecta");
                }

            } else
            {
                MessageBox.Show("Usuario no encontrado");
            }
        }
    }
}
