using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Administrador
{
    public class Administrador
    {
        Almacenamiento almacenamiento;

        public Administrador()
        {
            almacenamiento = new Almacenamiento();
        }

        public bool Crear(object objeto)
        {
            try
            {
                string nombreTabla = objeto.GetType().Name;
                var objetos = almacenamiento.LecturaDatos(nombreTabla);
                var objetosJson = JsonConvert.DeserializeObject<List<object>>(objetos);
                objetosJson.Add(objeto);
                var resultado = almacenamiento.EscrituraDatos(JsonConvert.SerializeObject(objetosJson), nombreTabla);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool Actualizar(object objeto, string opcionBusqueda)
        {
            try
            {
                string nombreTabla = objeto.GetType().Name;
                var objetos = almacenamiento.LecturaDatos(nombreTabla);
                var objetosJson = JsonConvert.DeserializeObject<List<object>>(objetos);
                var objetoJSON = JsonConvert.SerializeObject(objeto);
                
                object lo = null;

                var valorO = objeto.GetType().GetProperty(opcionBusqueda).GetValue(objeto);
                foreach (var x in objetosJson)
                {
                    var objetoActualJSON = JsonConvert.SerializeObject(x);
                    var propiedadBusqueda = JsonConvert.DeserializeObject<JObject>(objetoActualJSON)[opcionBusqueda];
                    var valorBusqueda = "";

                    try
                    {
                        valorBusqueda = propiedadBusqueda.Value<string>();
                    }
                    catch (Exception)
                    {
                    }
                    
                    if (valorO.ToString() == valorBusqueda)
                    {
                        lo = x;
                    }
                }

                objetosJson.Remove(lo);
                objetosJson.Add(objeto);

                var resultado = almacenamiento.EscrituraDatos(JsonConvert.SerializeObject(objetosJson), nombreTabla);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool Eliminar(object objeto)
        {
            try
            {
                string nombreTabla = objeto.GetType().Name;
                var objetos = almacenamiento.LecturaDatos(nombreTabla);
                var objetosJson = JsonConvert.DeserializeObject<List<object>>(objetos);
                var objetoJSON = JsonConvert.SerializeObject(objeto);

                //Operacion para eliminar
                object lo = null;

                foreach (var x in objetosJson)
                {
                    var objetoActualJSON = JsonConvert.SerializeObject(x);
                    if (objetoActualJSON == objetoJSON)
                    {
                        lo = x;
                        break;
                    }
                }
                
                objetosJson.Remove(lo);

                if (lo == null)
                {
                    return false;
                }
                
                var resultado = almacenamiento.EscrituraDatos(JsonConvert.SerializeObject(objetosJson), nombreTabla);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public object Buscar(string dato, string opcionBusqueda, string tabla)
        {
            try
            {
                var objetos = almacenamiento.LecturaDatos(tabla);
                var objetosJson = JsonConvert.DeserializeObject<List<object>>(objetos);
                
                foreach (var x in objetosJson)
                {
                    var objetoActualJSON = JsonConvert.SerializeObject(x);
                    var propiedadBusqueda = JsonConvert.DeserializeObject<JObject>(objetoActualJSON)[opcionBusqueda];
                    var valorBusqueda = "";

                    try
                    {
                        valorBusqueda = propiedadBusqueda.Value<string>();
                    }
                    catch (Exception)
                    {
                    }

                    if (dato == valorBusqueda)
                    {
                        return x;
                    }
                }

                return null;
            }
            catch (Exception)
            {

                return null;
            }
        }

        public List<object> Retornar(string tabla)
        {
            try
            {
                var Datos = almacenamiento.LecturaDatos(tabla);
                return JsonConvert.DeserializeObject<List<object>>(Datos);
            }
            catch (Exception)
            {

                return null;
            }
        }
    }
}
