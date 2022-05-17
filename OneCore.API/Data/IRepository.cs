using OneCore.API.DataModels;
using System.Collections.Generic;

namespace OneCore.API.Data
{
    public interface IRepository
    {
        public bool InsertarCliente(Cliente cliente);
        public bool EliminarCliente(Cliente cliente);
        public bool ActualizarCliente(Cliente cliente);
        public IEnumerable<Cliente> ObtenerClientes();
        public Cliente ObtenerCliente(int id);
        bool InsertarProductos(List<Producto> productos);
        List<Producto> ObtenerProductos(int idCliente);
    }
}
