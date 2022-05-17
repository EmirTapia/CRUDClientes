using OneCore.API.DataModels;
using System.Collections.Generic;

namespace OneCore.WEB.Models
{
    public class ProductosViewModel
    {
        public List<Producto> Productos { get; set; }
        public int ClienteId { get; set; }
    }
}
