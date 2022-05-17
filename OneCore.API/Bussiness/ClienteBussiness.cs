using OneCore.API.Models;
using System;
using System.Net;

namespace OneCore.API.Bussiness
{
    public static class ClienteBussiness<T>
    {
        public static Response RegistrarCliente(T cliente, bool exito)
        {
            if (exito)
            {
                return new Response
                {
                    Exito = true,
                    Mensaje = string.Format(MessageHelper.GenerateMessage(MessageType.RegistroClienteExitoso)),
                    HttpStatusCode = HttpStatusCode.Created,
                    Data = cliente
                };
            }
            else
            {
                return new Response
                {
                    Exito = false,
                    Mensaje = string.Format(MessageHelper.GenerateMessage(MessageType.RegistroClienteFallido)),
                    HttpStatusCode = HttpStatusCode.NotFound,
                    Data = cliente
                };
            }
        }

        public static Response ActualizarCliente(T cliente, bool exito)
        {
            if (exito)
            {
                return new Response
                {
                    Exito = true,
                    Mensaje = string.Format(MessageHelper.GenerateMessage(MessageType.ActualizacionClienteExitoso)),
                    HttpStatusCode = HttpStatusCode.OK,
                    Data = cliente
                };
            }
            else
            {
                return new Response
                {
                    Exito = false,
                    Mensaje = string.Format(MessageHelper.GenerateMessage(MessageType.ActualizacionClienteFallido)),
                    HttpStatusCode = HttpStatusCode.NotFound,
                    Data = cliente
                };
            }
        }

        public static Response EliminarCliente(T cliente, bool exito)
        {
            if (exito)
            {
                return new Response
                {
                    Exito = true,
                    Mensaje = string.Format(MessageHelper.GenerateMessage(MessageType.EliminacionClienteExitoso)),
                    HttpStatusCode = HttpStatusCode.OK,
                    Data = cliente
                };
            }
            else
            {
                return new Response
                {
                    Exito = false,
                    Mensaje = string.Format(MessageHelper.GenerateMessage(MessageType.EliminacionClienteFallido)),
                    HttpStatusCode = HttpStatusCode.NotFound,
                    Data = cliente
                };
            }
        }

        public static Response ObtenerClientes(T cliente)
        {
            if (cliente != null)
            {
                return new Response
                {
                    Exito = true,
                    Mensaje = string.Format(MessageHelper.GenerateMessage(MessageType.ObtenerClientesExitoso)),
                    HttpStatusCode = HttpStatusCode.OK,
                    Data = cliente
                };
            }
            else
            {
                return new Response
                {
                    Exito = false,
                    Mensaje = string.Format(MessageHelper.GenerateMessage(MessageType.ObtenerClientesFallido)),
                    HttpStatusCode = HttpStatusCode.NotFound,
                    Data = cliente
                };
            }
        }

        public static Response Excepcion(Exception Exception)
        {
            return new Response
            {
                Exito = true,
                Mensaje = string.Format(MessageHelper.GenerateMessage(MessageType.Excepcion)),
                HttpStatusCode = HttpStatusCode.Created,
                Exception = Exception
            };
        }
    }
}
