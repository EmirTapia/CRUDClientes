using Newtonsoft.Json;
using OneCore.API.DataModels;
using OneCore.API.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace OneCore.WEB.Services.OneCoreAppAPI
{
    public class Repository : IRepository
    {
        public async Task<Response> ActualizarClienteAsync(Cliente cliente)
        {
            var json = JsonConvert.SerializeObject(cliente);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            var url = "https://localhost:44331/api/Clientes";
            using var client = new HttpClient();

            var response = await client.PutAsync(url, data);
            var result = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Response>(result);
        }

        public async Task<Response> EliminarClienteAsync(Cliente cliente)
        {
            var json = JsonConvert.SerializeObject(cliente);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            var url = $"https://localhost:44331/api/Clientes/{cliente.Id}";

            using var client = new HttpClient();

            var response = await client.DeleteAsync(url);
            var result = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Response>(result);
        }

        public async Task<Response> InsertarClienteAsync(Cliente cliente)
        {
            var json = JsonConvert.SerializeObject(cliente);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            var url = "https://localhost:44331/api/Clientes";
            using var client = new HttpClient();

            var response = await client.PostAsync(url, data);
            var result = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Response>(result);
        }

        public async Task<Response> InsertarProductosAsync(int id)
        {           

            var url = $"https://localhost:44331/api/Productos/{id}";
            using var client = new HttpClient();

            var response = await client.PostAsync(url, null);
            var result = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Response>(result);
        }

        public Task<Response> ObtenerClienteAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<Response> ObtenerClientesAsync()
        {
            try
            {
                var httpClient = new HttpClient();
                var productsList = new Response();
                var json = await httpClient.GetStringAsync("https://localhost:44331/api/Clientes");
                var response = JsonConvert.DeserializeObject<Response>(json);
                var json1 = JsonConvert.SerializeObject(response.Data);
                response.Data = JsonConvert.DeserializeObject<List<Cliente>>(json1);
                return response;
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public Task<Response> ObtenerProductosAsync(int idCliente)
        {
            throw new System.NotImplementedException();
        }
    }
}
