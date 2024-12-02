using Microsoft.AspNetCore.Mvc;
using SaraLemus._2024.PruebaTecnica.BL;
using SaraLemus._2024.PruebaTecnica.EN;

namespace SaraLemus._2024.PruebaTecnica.Controllers
{
    public class CategoriaController : Controller
    {
        private readonly CategoriaBL _categoriaBL;

        public CategoriaController(CategoriaBL categoriaBL)
        {
            _categoriaBL = categoriaBL;
        }

        // Acción para mostrar todas las categorías
        public IActionResult Index()
        {
            // Obtenemos la lista de categorías del servicio BL
            var categorias = _categoriaBL.ObtenerCategorias();

            // Pasamos el modelo correcto a la vista, que es IEnumerable<Categoria> y no IEnumerable<CategoriaBL>
            return View(categorias);
        }

        // Acción para mostrar los detalles de una categoría
        public IActionResult Details(int id)
        {
            // Obtenemos la categoría por su ID
            var categoria = _categoriaBL.ObtenerCategoriaPorId(id);
            if (categoria == null)
            {
                // Si no se encuentra la categoría, retornamos NotFound
                return NotFound();
            }

            // Pasamos la categoría a la vista
            return View(categoria);
        }

        // Acción para mostrar el formulario de creación
        public IActionResult Create()
        {
            return View();
        }

        // Acción POST para crear una categoría
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Categoria categoria)
        {
            if (ModelState.IsValid)
            {
                // Si el modelo es válido, agregamos la categoría a la base de datos
                _categoriaBL.AgregarCategoria(categoria);
                // Redirigimos al índice para mostrar la lista de categorías
                return RedirectToAction(nameof(Index));
            }

            // Si el modelo no es válido, volvemos a mostrar el formulario con los errores
            return View(categoria);
        }

        // Acción para mostrar el formulario de edición
        public IActionResult Edit(int id)
        {
            var categoria = _categoriaBL.ObtenerCategoriaPorId(id);
            if (categoria == null)
            {
                return NotFound();
            }

            return View(categoria);
        }

        // Acción POST para editar una categoría
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Categoria categoria)
        {
            if (id != categoria.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _categoriaBL.ActualizarCategoria(categoria);
                return RedirectToAction(nameof(Index));
            }

            return View(categoria);
        }

        // Acción para mostrar la vista de eliminación
        public IActionResult Delete(int id)
        {
            var categoria = _categoriaBL.ObtenerCategoriaPorId(id);
            if (categoria == null)
            {
                return NotFound();
            }

            return View(categoria);
        }

        // Acción POST para confirmar la eliminación de una categoría
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _categoriaBL.EliminarCategoria(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
