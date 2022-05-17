using Microsoft.EntityFrameworkCore;
using OneCore.API.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OneCore.API.Data
{
    public class Repository : IRepository
    {
        private readonly Context _context;
        public Repository(Context context)
        {
            _context = context;
        }

        public bool ActualizarCliente(Cliente cliente)
        {
            try
            {
                cliente.Activo = true;
                _context.Cliente.Update(cliente);
                _context.SaveChanges();
                return true;
            }
            catch (System.Exception)
            {
                return false;
            }
        }

        public bool EliminarCliente(Cliente cliente)
        {
            try
            {
                cliente.Activo = false;
                _context.Update(cliente);
                _context.SaveChanges();

                return true;
            }
            catch (System.Exception)
            {
                return false;
            }
        }

        public bool InsertarCliente(Cliente cliente)
        {
            try
            {
                cliente.Activo = true;
                _context.Add(cliente);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public Cliente ObtenerCliente(int cliente)
        {
            try
            {
                return _context.Cliente.
                                Where(x => x.Id == cliente && x.Activo).
                                FirstOrDefault();
            }
            catch (Exception)
            {
                return null;
            }
            
        }

        public IEnumerable<Cliente> ObtenerClientes()
        {
            try
            {
                return _context.Cliente.
                                Where(x => x.Activo).Include(s => s.Productos).
                                ToList();
            }
            catch (Exception)
            {
                return null;
            }
            
        }

        public bool InsertarProductos(List<Producto> productos)
        {
            try
            {
                _context.Producto.AddRange(productos);
                _context.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<Producto> ObtenerProductos(int idCliente)
        {
            try
            {
                var cliente = _context?.Cliente?.Where(x => x.Id == idCliente && x.Activo);
                if (cliente == null)
                    return null;
                return _context.Producto.Where(x => x.ClienteId == idCliente).ToList();
            }
            catch (Exception)
            {
                return null;
            }   
        }
    }
}
