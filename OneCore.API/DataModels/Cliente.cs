using System.Collections.Generic;

namespace OneCore.API.DataModels
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Rfc { get; set; }
        public string Direccion { get; set; }
        public string Cp { get; set; }
        public string CorreoContacto { get; set; }
        public List<Producto> Productos { get; set; }

        public bool Activo { get; set; }
    }
}
