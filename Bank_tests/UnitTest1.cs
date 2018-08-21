using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Administrador;
using Distribuidora;

namespace Bank_tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void RetornarDatos()
        {
            Administrador.Administrador admin = new Administrador.Administrador();
            try
            {
                var a = admin.Retornar("Tabla");
                Assert.IsTrue(a != null);
            }
            catch (Exception)
            {
                Assert.IsTrue(false);
            }
        }

        /*[TestMethod]
        public void CrearDatos()
        {
            Administrador.Administrador admin = new Administrador.Administrador();
            try
            {
                Distribuidora.Model.Usuario user = new Distribuidora.Model.Usuario() {
                    IdUsuario = "Prueba3",
                    Nombre = "P3",
                    Rol = 1,
                    Contraseña = "1233"
                };

                var a = admin.Crear(user);

                Assert.IsTrue(a == true);
            }
            catch (Exception)
            {
                Assert.IsTrue(false);
            }
        }

        [TestMethod]
        public void EliminarDatos()
        {
            Administrador.Administrador admin = new Administrador.Administrador();
            try
            {
                Distribuidora.Model.Usuario user = new Distribuidora.Model.Usuario()
                {
                    IdUsuario = "Prueba3",
                    Nombre = "P3",
                    Rol = 1,
                    Contraseña = "1233"
                };

                var a = admin.Eliminar(user);

                Assert.IsTrue(a == true);
            }
            catch (Exception)
            {
                Assert.IsTrue(false);
            }
        }

        [TestMethod]
        public void ActualizarDatos()
        {
            Administrador.Administrador admin = new Administrador.Administrador();
            try
            {
                Distribuidora.Model.Usuario user = new Distribuidora.Model.Usuario()
                {
                    IdUsuario = "Prueba2",
                    Nombre = "REMPLAZO",
                    Rol = 1,
                    Contraseña = "543"
                };
                var a = admin.Actualizar(user, "IdUsuario");

                Assert.IsTrue(a == true);
            }
            catch (Exception)
            {
                Assert.IsTrue(false);
            }
        }

        [TestMethod]
        public void BuscarDato()
        {
            Administrador.Administrador admin = new Administrador.Administrador();
            try
            {
                var a = admin.Buscar("Prueba2","IdUsuario","Usuario");

                if (a != null)
                {
                    Assert.IsTrue(true);
                } else
                {
                    Assert.IsTrue(false);
                }
            }
            catch (Exception)
            {
                Assert.IsTrue(false);
            }
        }

        [TestMethod]
        public void CrearDatosOtrasTablas()
        {
            Administrador.Administrador admin = new Administrador.Administrador();
            try
            {
                /*admin.Crear(new Distribuidora.Model.Rol() { Identificador = 1, Nombre = "Administrador" });
                admin.Crear(new Distribuidora.Model.Rol() { Identificador = 2, Nombre = "Operador" });
                admin.Crear(new Distribuidora.Model.Rol() { Identificador = 3, Nombre = "Visualizador" });

                admin.Crear(new Distribuidora.Model.Departamento() { Id=1, Nombre="Contabilidad" });
                admin.Crear(new Distribuidora.Model.Departamento() { Id = 1, Nombre = "IT" });
                admin.Crear(new Distribuidora.Model.Departamento() { Id = 1, Nombre = "Bodega" });
                admin.Crear(new Distribuidora.Model.Departamento() { Id = 1, Nombre = "Gerente" });

                admin.Crear(new Distribuidora.Model.Supermercado() { Id=1, Nombre="paizMart", Direccion="Zona 14", Telefono="45843615" });
                admin.Crear(new Distribuidora.Model.Supermercado() { Id = 1, Nombre = "Almacenes Robles", Direccion = "Zona 1", Telefono = "55847596" });
                admin.Crear(new Distribuidora.Model.Supermercado() { Id = 1, Nombre = "Despensa", Direccion = "Chiquimula", Telefono = "47484945" });
                
                admin.Crear(new Distribuidora.Model.Producto() { Id = 1, Nombre = "Jabon", Descripcion="Jabon para manos", Precio=15.50M});
                admin.Crear(new Distribuidora.Model.Producto() { Id = 1, Nombre = "Desodorante", Descripcion = "Desodorante antitranspirante", Precio = 17.00M });
                admin.Crear(new Distribuidora.Model.Producto() { Id = 1, Nombre = "Crema", Descripcion = "Crema para manos", Precio = 06.25M });*/
                /*Assert.IsTrue(true);
            }
            catch (Exception)
            {
                Assert.IsTrue(false);
            }
        }*/
    }
}
