using Microsoft.AspNetCore.Mvc;
using OneCore.API.Models;
using OneCore.WEB.Extensions;
using OneCore.WEB.Services.OneCoreAppAPI;
using System;
using System.Linq;

namespace OneCore.WEB.Controllers.Clientes
{
    public class ClientesController : BaseController
    {
        private readonly IRepository _repository;
        public ClientesController(Repository repository)
        {
            _repository = repository;
        }
        public ActionResult Index()
        {
            try
            {
                var result = _repository.ObtenerClientesAsync().Result;
                return View(result.Data);
            }
            catch (Exception)
            {
                return View(null);
            }            
        }

        [HttpPost]
        public ActionResult Create(Cliente cliente)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    string messages = "Favor de ingresar todos los campos.";
                    BasicNotification(messages, 
                                      NotificationType.Error);
                    return RedirectToAction(nameof(Index));
                }
                if (cliente.Id == 0)
                {
                    var resultadoInsercion = _repository.InsertarClienteAsync(cliente).Result;
                    BasicNotification(resultadoInsercion.Mensaje, NotificationType.Success);
                    if (resultadoInsercion.Exito)
                        BasicNotification(resultadoInsercion.Mensaje, NotificationType.Success);
                    else
                        BasicNotification(resultadoInsercion.Mensaje, NotificationType.Error);
                }
                else
                {
                    var resultadoActualizacion = _repository.ActualizarClienteAsync(cliente).Result;
                    if (resultadoActualizacion.Exito)
                        BasicNotification(resultadoActualizacion.Mensaje, NotificationType.Success);
                    else
                        BasicNotification(resultadoActualizacion.Mensaje, NotificationType.Error);                    
                }                
            }
            catch (Exception ex)
            {
                BasicNotification(ex.InnerException.Message , NotificationType.Error);
            }
            return RedirectToAction(nameof(Index));

        }

        [HttpPost]
        public ActionResult Delete(Cliente cliente)
        {
            try
            {
                var resultado = _repository.EliminarClienteAsync(cliente).Result;
                if (resultado.Exito)
                    BasicNotification(resultado.Mensaje, NotificationType.Success);
                else
                    BasicNotification(resultado.Mensaje, NotificationType.Error);                
            }
            catch (Exception ex)
            {
                BasicNotification(ex.InnerException.Message, NotificationType.Error);
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
