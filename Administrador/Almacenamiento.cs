using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Administrador
{
    class Almacenamiento
    {
        public string Ruta { get; set; }

        public Almacenamiento()
        {
            //Ruta = @"C:\Users\lfflo\OneDrive\Documentos\Universidad\Diseño de software\ExamenParcial1\Almacenamiento";
            Ruta = @"\Almacenamiento";
            //Ruta = @"C:\Users\lflorian\Documents\FLORIAN\ExamenParcial1\Almacenamiento";
        }

        public string LecturaDatos(string tabla)
        {
            try
            {
                string RutaFinal = RetornarPath(tabla);
                var tablaFile = "";

                if (!File.Exists(RutaFinal))
                {
                    using (StreamWriter sw = File.CreateText(RutaFinal))
                    {
                        sw.WriteLine("[{}]");
                    }
                    tablaFile = File.ReadAllText(RutaFinal);
                } else
                {
                    tablaFile = File.ReadAllText(RutaFinal);
                }

                return tablaFile;
            }
            catch (Exception es)
            {
                return null;
            }
        }

        public bool EscrituraDatos(string objetos, string tabla)
        {
            try
            {
                string RutaFinal = RetornarPath(tabla);
                try
                {
                    File.WriteAllText(RutaFinal, objetos);
                }
                catch (Exception)
                {
                    CrearTabla(tabla);
                    File.WriteAllText(RutaFinal, objetos);
                }
                
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private void CrearTabla(string tabla)
        {
            string RutaFinal = RetornarPath(tabla);
            File.Create(RutaFinal);
            File.WriteAllText(RutaFinal, "[{}]");
        }

        private string RetornarPath(string tabla)
        {
            return Path.Combine(Directory.GetCurrentDirectory() + Ruta, tabla + ".txt");
        }
    }
}
