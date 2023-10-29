using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConsumoLaravel.Models
{
    public class ListarProductos
    {
        public List<Data> data { get; set; }
       
    }
    public class Data
    {
        public string name { get; set; }
        public string descripcion { get; set; }
        public string precio { get; set; }
    } 
}