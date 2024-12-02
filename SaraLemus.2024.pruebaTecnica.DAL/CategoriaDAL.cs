using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SaraLemus._2024.PruebaTecnica.EN;

namespace SaraLemus._2024.pruebaTecnica.DAL
{
        public class CategoriaDAL
        {
            private readonly AppDbContext _context;

            public CategoriaDAL(AppDbContext context)
            {
                _context = context;
            }

            // Obtener todas las categorías
            public List<Categoria> ObtenerCategorias()
            {
                return _context.Categorias.ToList();
            }

            // Agregar una categoría
            public void AgregarCategoria(Categoria categoria)
            {
                _context.Categorias.Add(categoria);
                _context.SaveChanges();
            }

            // Actualizar una categoría
            public void ActualizarCategoria(Categoria categoria)
            {
                _context.Categorias.Update(categoria);
                _context.SaveChanges();
            }

            // Eliminar una categoría
            public void EliminarCategoria(int id)
            {
                var categoria = _context.Categorias.Find(id);
                if (categoria != null)
                {
                    _context.Categorias.Remove(categoria);
                    _context.SaveChanges();
                }
            }

            // Obtener una categoría por ID
            public Categoria ObtenerCategoriaPorId(int id)
            {
                return _context.Categorias.Find(id);
            }
        }
    
}
