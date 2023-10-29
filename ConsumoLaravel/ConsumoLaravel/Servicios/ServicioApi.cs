using ConsumoLaravel.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;

namespace ConsumoLaravel.Servicios
{
    public class ServicioApi : IServicioApi
    {
        private string _baseurl;
        private string _token; // Variable para almacenar el token de acceso

        public ServicioApi()
        {
            _baseurl = "http://127.0.0.1:8000/";
        }

        public async Task<Producto> BuscarProducto(string id)
        {
            Producto producto = new Producto();
            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseurl);

            var ur = "/api/productos"+ id;
            var response = await cliente.GetAsync(ur);

            if (response.IsSuccessStatusCode)
            {
                var json_response = await response.Content.ReadAsStringAsync();
                var resultado = JsonConvert.DeserializeObject<Producto>(json_response);
                producto = resultado;
            }

            return producto;
        }

        public async Task<ResponseProducto> CrearProducto(RequestProducto pro)
        {
            ResponseProducto producto = new ResponseProducto();
            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseurl);

            // Crear datos de formulario con los campos necesarios
            var formData = new MultipartFormDataContent();
            formData.Add(new StringContent(pro.name), "name");
            formData.Add(new StringContent(pro.descripcion), "descripcion");
            formData.Add(new StringContent(pro.precio.ToString()), "precio");

            // Agregar encabezado personalizado si es necesario
            cliente.DefaultRequestHeaders.Add("X-Requested-With", "XMLHttpRequest");

            var ur = "/api/productos";
            var response = await cliente.PostAsync(ur, formData);

            if (response.IsSuccessStatusCode)
            {
                var json_respuesta = await response.Content.ReadAsStringAsync();
                var resultado = JsonConvert.DeserializeObject<ResponseProducto>(json_respuesta);
                producto = resultado;
            }
            return producto;
        }


        // Método para autenticar y obtener el token de acceso

        public async Task<ListarProductos> Listarproducto()
        {

            var listar = new ListarProductos();
            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseurl);
     

            var ur = "/api/productos";
            var response = await cliente.GetAsync(ur);

            if (response.IsSuccessStatusCode)
            {
                var json_response = await response.Content.ReadAsStringAsync();
                listar = JsonConvert.DeserializeObject<ListarProductos>(json_response);
            }

            return listar;
        }



    }
}
