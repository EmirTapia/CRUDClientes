using Microsoft.AspNetCore.Mvc;
using OneCore.WEB.Extensions;
using OneCore.WEB.Services.OneCoreAppAPI;
using System;

namespace OneCore.WEB.Controllers.Productos
{
    public class ProductosController : BaseController
    {
        private readonly IRepository _repository;
        public ProductosController(Repository repository)
        {
            _repository = repository;
        }
        public IActionResult Agregar(int id)
        {
            try
            {
                var resultado = _repository.InsertarProductosAsync(id).Result;
                if (resultado.Exito)
                    BasicNotification(resultado.Mensaje, NotificationType.Success);
                else
                    BasicNotification(resultado.Mensaje, NotificationType.Error);                
            }
            catch (Exception ex)
            {
                BasicNotification(ex.Message, NotificationType.Error);
            }
            return RedirectToAction("Index", "Clientes");
        }
    }
}
