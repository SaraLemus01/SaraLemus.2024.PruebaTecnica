using System;
using System.Collections.Generic;
using SaraLemus._2024.pruebaTecnica.DAL;
using SaraLemus._2024.PruebaTecnica.EN;

namespace SaraLemus._2024.PruebaTecnica.BL
{
    public class ProductoBL
    {
        private readonly ProductoDAL _productoDAL;

        public ProductoBL(ProductoDAL productoDAL)
        {
            _productoDAL = productoDAL;
        }

        public List<Producto> ObtenerProductos()
        {
            return _productoDAL.ObtenerProductos();
        }

        public void AgregarProducto(Producto producto)
        {
            _productoDAL.AgregarProducto(producto);
        }

        public void ActualizarProducto(Producto producto)
        {
            _productoDAL.ActualizarProducto(producto);
        }

        public void EliminarProducto(int id)
        {
            var producto = _productoDAL.ObtenerProductoPorId(id);
            if (producto == null)
            {
                throw new System.Exception("El producto no existe.");
            }

            _productoDAL.EliminarProducto(id);
        }

        public Producto ObtenerProductoPorId(int id)
        {
            return _productoDAL.ObtenerProductoPorId(id);
        }
    }
}
