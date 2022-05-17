using System;
using System.Net;

namespace OneCore.API.Models
{
    public class Response
    {
        public HttpStatusCode HttpStatusCode { get; set; }
        public bool Exito { get; set; }
        public string Mensaje { get; set; }
        public Exception Exception { get; set; }
        public dynamic Data { get; set; }

    }
}
