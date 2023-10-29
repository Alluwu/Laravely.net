using ConsumoLaravel.Models;
using ConsumoLaravel.Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace ConsumoLaravel.Controllers
{
    [RoutePrefix("api")]
    public class LaravelController : ApiController
    {
        private readonly IServicioApi _servicioApi;
        public LaravelController()
        {
            _servicioApi = new ServicioApi();
        }
        Mensaje mensaje = new Mensaje();
        [HttpPost]
        [Route("Crear")]
        public async Task<IHttpActionResult> Post(Entrada entrada)
        {
            if (entrada.metodo != null && entrada.metodo != string.Empty)
            {
                switch (entrada.metodo)
                {
                    case "Lista":
                        ListarProductos lista = await _servicioApi.Listarproducto();
                        if (lista != null)
                        {
                            return Ok(lista);
                        }
                        else
                        {
                            var respuesta = new Mensaje()
                            {
                                Respuesta = 2,
                                Contenido = "Error al cargar la lista" + entrada.metodo
                            };
                            return BadRequest(respuesta.Contenido);
                        }

                    case "CrearProducto":
                        ResponseProducto producto = await _servicioApi.CrearProducto(entrada.producto);
                        if (producto != null) 
                        {
                            return Ok(producto);
                        }
                        else
                        {
                            var respuesta2 = new Mensaje()
                            {
                                Respuesta = 2,
                                Contenido = "Error al guardar el producto" + entrada.metodo
                            };
                            return BadRequest(respuesta2.Contenido);
                        }
                    case "ConsultarProducto":
                        Producto consulta = await _servicioApi.BuscarProducto(entrada.id);
                            if(consulta != null)
                            {
                                return Ok(consulta);
                            }
                        else
                        {
                            var respuesta3 = new Mensaje()
                            {
                                Respuesta = 2,
                                Contenido = "Error al consultar" + entrada.metodo
                            };
                            return BadRequest(respuesta3.Contenido);
                        }
                    default:
                        /*Respuesta que se retorna en caso de ingresar un metodo no valido*/
                        var noExisteMetodo = new Mensaje()
                        {
                            Respuesta = 5,
                            Contenido = "No existe el metodo: " + entrada.metodo
                        };
                        return Content(HttpStatusCode.NotFound, noExisteMetodo);
                }
            }
            mensaje.Respuesta = 0;
            mensaje.Contenido = "Error en el parametro Metodo";
            return BadRequest(mensaje.Contenido);
        }
    }

}
