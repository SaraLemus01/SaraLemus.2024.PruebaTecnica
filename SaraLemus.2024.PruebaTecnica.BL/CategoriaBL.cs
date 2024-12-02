using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SaraLemus._2024.pruebaTecnica.DAL;
using SaraLemus._2024.PruebaTecnica.EN;

namespace SaraLemus._2024.PruebaTecnica.BL
{
    public class CategoriaBL
    {
        private readonly CategoriaDAL _categoriaDAL;

        public CategoriaBL(CategoriaDAL categoriaDAL)
        {
            _categoriaDAL = categoriaDAL;
        }

        // Obtener todas las categorías
        public List<Categoria> ObtenerCategorias()
        {
            return _categoriaDAL.ObtenerCategorias();
        }

        // Agregar una categoría (con validación de negocio)
        public void AgregarCategoria(Categoria categoria)
        {
            if (string.IsNullOrWhiteSpace(categoria.Nombre))
            {
                throw new System.Exception("El nombre de la categoría no puede estar vacío.");
            }

            _categoriaDAL.AgregarCategoria(categoria);
        }

        // Actualizar una categoría (con validación)
        public void ActualizarCategoria(Categoria categoria)
        {
            if (string.IsNullOrWhiteSpace(categoria.Nombre))
            {
                throw new System.Exception("El nombre de la categoría no puede estar vacío.");
            }

            _categoriaDAL.ActualizarCategoria(categoria);
        }

        // Eliminar una categoría por ID (con reglas)
        public void EliminarCategoria(int id)
        {
            var categoria = _categoriaDAL.ObtenerCategoriaPorId(id);
            if (categoria == null)
            {
                throw new System.Exception("La categoría no existe.");
            }

            _categoriaDAL.EliminarCategoria(id);
        }

        // Obtener una categoría por ID
        public Categoria ObtenerCategoriaPorId(int id)
        {
            return _categoriaDAL.ObtenerCategoriaPorId(id);
        }
    }
}

