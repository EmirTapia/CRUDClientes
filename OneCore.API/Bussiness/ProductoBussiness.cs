using OneCore.API.Models;
using System.Net;

namespace OneCore.API.Bussiness
{
    public static class ProductoBussiness<T>
    {
        public static Response RegistrarProductos(T productos, bool exito)
        {
            if (exito)
            {
                return new Response
                {
                    Exito = true,
                    Mensaje = string.Format(MessageHelper.GenerateMessage(MessageType.CargaProductosExitoso)),
                    HttpStatusCode = HttpStatusCode.Created,
                    Data = productos
                };
            }
            else
            {
                return new Response
                {
                    Exito = false,
                    Mensaje = string.Format(MessageHelper.GenerateMessage(MessageType.CargaProductosFallido)),
                    HttpStatusCode = HttpStatusCode.NotFound,
                    Data = productos
                };
            }
        }

        public static Response ObtenerProductos(T productos)
        {
            if (productos != null)
            {
                return new Response
                {
                    Exito = true,
                    Mensaje = string.Format(MessageHelper.GenerateMessage(MessageType.ObtenerProductosExitoso)),
                    HttpStatusCode = HttpStatusCode.OK,
                    Data = productos
                };
            }
            else
            {
                return new Response
                {
                    Exito = false,
                    Mensaje = string.Format(MessageHelper.GenerateMessage(MessageType.ObtenerProductosFallido)),
                    HttpStatusCode = HttpStatusCode.NotFound,
                    Data = productos
                };
            }
        }

        public static Response Excepcion(string message)
        {            
             return new Response
             {
                 Exito = false,
                 Mensaje = string.Format(MessageHelper.GenerateMessage(MessageType.Excepcion), message),
                 HttpStatusCode = HttpStatusCode.OK,
                 Data = null
             };            
        }
    }
}
