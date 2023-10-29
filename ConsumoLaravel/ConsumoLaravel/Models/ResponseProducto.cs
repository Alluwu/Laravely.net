using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConsumoLaravel.Models
{
    public class ResponseProducto
    {
        public Data1 data { get; set; }
    }
    public class Data1
    {
        public string Name { get; set; }
        public string Descripcion { get; set; }
        public string Precio { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime CreatedAt { get; set; }
        public int Id { get; set; }
    }
}