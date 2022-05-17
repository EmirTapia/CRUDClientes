using OneCore.API.Models;
using System.Threading.Tasks;

namespace OneCore.WEB.Services.OneCoreAppAPI
{
    public interface IRepository
    {
        public Task<Response> InsertarClienteAsync(Cliente cliente);
        public Task<Response> EliminarClienteAsync(Cliente cliente);
        public Task<Response> ActualizarClienteAsync(Cliente cliente);
        public Task<Response> ObtenerClientesAsync();
        public Task<Response> ObtenerClienteAsync(int id);
        Task<Response> InsertarProductosAsync(int id);
        Task<Response> ObtenerProductosAsync(int idCliente);
    }
}
