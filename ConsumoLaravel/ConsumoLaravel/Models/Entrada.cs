using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConsumoLaravel.Models
{
    public class Entrada
    {
        public string metodo { get; set; }
        public RequestProducto producto{ get; set; }
        public string id { get; set; }
    }
}