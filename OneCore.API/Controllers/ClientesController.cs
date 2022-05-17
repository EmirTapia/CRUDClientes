using Microsoft.AspNetCore.Mvc;
using OneCore.API.Bussiness;
using OneCore.API.Data;
using OneCore.API.DataModels;
using System;
using System.Collections.Generic;
using System.Net;

namespace OneCore.API.Controllers
{
    [ApiController]
    [Route("api/clientes")]
    public class ClientesController : ControllerBase
    {
        private readonly IRepository _cliente;

        public ClientesController(Repository cliente)
        {
            _cliente = cliente;
        }

        [HttpPost]
        public IActionResult RegistrarCliente([FromBody] Cliente cliente)
        {
            try
            {                
                bool seInserto = _cliente.InsertarCliente(cliente);
                if (seInserto)
                {
                    var response = ClienteBussiness<Cliente>.RegistrarCliente(cliente, seInserto);
                    return Created(string.Empty, response);
                }
                else
                {
                    var response = ClienteBussiness<Cliente>.RegistrarCliente(cliente, seInserto);
                    return NotFound(response);
                }
            }
            catch (Exception ex)
            {
                var response = ClienteBussiness<Cliente>.Excepcion(ex);
                return StatusCode((int)HttpStatusCode.InternalServerError, response);
            }
        }

        [HttpGet]
        public IActionResult ObtenerClientes()
        {
            try
            {
                var clientes = _cliente.ObtenerClientes();
                var response = ClienteBussiness<IEnumerable<Cliente>>.ObtenerClientes(clientes);
                if (response.Exito)
                    return Ok(response);
                return NotFound(response);
            }
            catch (Exception ex)
            {
                var response = ClienteBussiness<Cliente>.Excepcion(ex);
                return StatusCode((int)HttpStatusCode.InternalServerError, response);
            }
        }

        [HttpGet, Route("{id}")]
        public IActionResult ObtenerCliente(int id)
        {
            try
            {
                var cliente = _cliente.ObtenerCliente(id);
                var response = ClienteBussiness<Cliente>.ObtenerClientes(cliente);
                if (response.Exito)
                    return Ok(response);
                return NotFound(response);
            }
            catch (Exception ex)
            {
                var response = ClienteBussiness<Cliente>.Excepcion(ex);
                return StatusCode((int)HttpStatusCode.InternalServerError, response);
            }
        }

        [HttpPut]
        public IActionResult ActualizarCliente([FromBody] Cliente cliente)
        {
            try
            {
                bool seActualizo = _cliente.ActualizarCliente(cliente);
                var response = ClienteBussiness<Cliente>.ActualizarCliente(cliente, seActualizo);
                if (response.Exito)
                    return Ok(response);
                return NotFound(response);
            }
            catch (Exception ex)
            {
                var response = ClienteBussiness<Cliente>.Excepcion(ex);
                return StatusCode((int)HttpStatusCode.InternalServerError, response);
            }
        }

        [HttpDelete, Route("{id}")]
        public IActionResult EliminarCliente(int id)
        {
            try
            {
                var cliente = _cliente.ObtenerCliente(id);
                var clienteResponse = ClienteBussiness<Cliente>.ObtenerClientes(cliente);

                if (!clienteResponse.Exito)
                    return NotFound(clienteResponse);


                bool seElimino = _cliente.EliminarCliente(cliente);
                var response = ClienteBussiness<Cliente>.EliminarCliente(cliente, seElimino);
                if (response.Exito)
                    return Ok(response);
                return NotFound(response);

            }
            catch (Exception ex)
            {
                var response = ClienteBussiness<Cliente>.Excepcion(ex);
                return StatusCode((int)HttpStatusCode.InternalServerError, response);
            }
        }
    }
}
