using Microsoft.Extensions.Configuration;
using OneCore.API.DataModels;
using SpreadsheetLight;
using System;
using System.Collections.Generic;

namespace OneCore.API.Services
{
    public static class Excel
    {

        private static string _rutaExcel = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("Excel")["Local"];

        public static List<Producto> LeerArchivoExcel(int id)
        {
            try
            {
                string path = _rutaExcel;
                var productos = new List<Producto>();
                var doc = new SLDocument(path);
                int row = 2;
                while (!string.IsNullOrEmpty(doc.GetCellValueAsString(row, 1)))
                {
                    Producto producto = new Producto
                    {
                        ClienteId = id,
                        Cantidad = doc.GetCellValueAsInt32(row, 1),
                        Descripcion = doc.GetCellValueAsString(row, 2),
                        Precio = doc.GetCellValueAsDecimal(row, 3),
                        Total = doc.GetCellValueAsDecimal(row, 4),
                    };
                    productos.Add(producto);
                    row++;
                }
                doc.Dispose();
                return productos;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
