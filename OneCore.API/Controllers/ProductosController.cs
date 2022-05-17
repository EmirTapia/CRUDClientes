using Microsoft.AspNetCore.Mvc;
using OneCore.API.Bussiness;
using OneCore.API.Data;
using OneCore.API.DataModels;
using OneCore.API.Services;
using System;
using System.Collections.Generic;
using System.Net;

namespace OneCore.API.Controllers
{
    [ApiController,  Route("api/[controller]")]
    public class ProductosController : Controller
    {
        private readonly IRepository _productos;

        public ProductosController(Repository productos)
        {
            _productos = productos;
        }

        [HttpPost, Route("{id}")]
        public IActionResult Insertar(int id)
        {
            try
            {
                var productos = Excel.LeerArchivoExcel(id);
                if (productos == null)
                    return BadRequest();

                bool seInsertaronProductos = _productos.InsertarProductos(productos);
                var response = ProductoBussiness<List<Producto>>.RegistrarProductos(productos, seInsertaronProductos);

                if (response.Exito)
                {
                    var cliente = _productos.ObtenerCliente(id);
                    if (productos.Count < 18)
                    {
                        EmailSender.EnviarCorreo(cliente, productos);
                    }
                    else {
                        EmailSender.EnviarCorreoAdjunto(cliente, productos.Count);
                    }
                }

                if (response.Exito)
                    return Ok(response);
                return NotFound(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ProductoBussiness<Cliente>.Excepcion(ex.Message));
            }
        }

        [HttpGet, Route("{id}")]
        public IActionResult Obtener(int id)
        {
            try
            {
                var productos = _productos.ObtenerProductos(id);
                var response = ProductoBussiness<List<Producto>>.ObtenerProductos(productos);
                if (response.Exito)
                    return Ok(response);
                return NotFound(response);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex);
            }
        }
    }
}
