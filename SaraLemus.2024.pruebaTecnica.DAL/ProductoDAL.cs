using SaraLemus._2024.PruebaTecnica.EN;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace SaraLemus._2024.pruebaTecnica.DAL
{
    public class ProductoDAL
    {
        private readonly AppDbContext _context;

        public ProductoDAL(AppDbContext context)
        {
            _context = context;
        }

        // Obtener todos los productos
        public List<Producto> ObtenerProductos()
        {
            return _context.Productos.ToList();
        }

        // Agregar Producto
        public void AgregarProducto(Producto producto)
        {
            _context.Productos.Add(producto);
            _context.SaveChanges();
        }

        // Actualizar Producto
        public void ActualizarProducto(Producto producto)
        {
            try
            {
                _context.Productos.Update(producto);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar el producto: " + ex.Message);
            }
        }

        // Eliminar Producto
        public void EliminarProducto(int id)
        {
            try
            {
                var producto = _context.Productos.Find(id);
                if (producto != null)
                {
                    _context.Productos.Remove(producto);
                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar el producto: " + ex.Message);
            }
        }

        // Obtener un Producto por ID
        public Producto ObtenerProductoPorId(int id)
        {
            return _context.Productos.Find(id);
        }
    }
}
