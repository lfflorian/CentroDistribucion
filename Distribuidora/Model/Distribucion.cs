using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Distribuidora.Model
{
    public class Distribucion
    {
        public int Id { get; set; }
        public string IdProducto { get; set; }
        public string IdSupermercado { get; set; }
        public int Cantidad { get; set; }
        public decimal Total { get; set; }
    }
}
