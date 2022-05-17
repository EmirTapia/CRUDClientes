using OneCore.API.DataModels;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OneCore.API.Models
{
    public class Cliente
    {

        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es un campo obligatorio")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El RFC es un campo obligatorio")]

        public string Rfc { get; set; }

        [Required(ErrorMessage = "La direccion es un campo obligatorio")]

        public string Direccion { get; set; }

        [Required(ErrorMessage = "El codigo postal es un campo obligatorio")]

        public string Cp { get; set; }

        [Required(ErrorMessage = "El correo de contacto es un campo obligatorio")]

        public string CorreoContacto { get; set; }
        public List<Producto> Productos {get;set;}
    }
}
