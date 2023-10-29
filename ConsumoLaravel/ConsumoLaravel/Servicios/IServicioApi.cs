using ConsumoLaravel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsumoLaravel.Servicios
{
    internal interface IServicioApi
    {
        Task <ListarProductos> Listarproducto();
        Task<ResponseProducto> CrearProducto(RequestProducto pro);
        Task<Producto> BuscarProducto(string id);

    }
}
