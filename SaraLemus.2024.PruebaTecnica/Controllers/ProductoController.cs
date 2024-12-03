using Microsoft.AspNetCore.Mvc;
using SaraLemus._2024.PruebaTecnica.BL;
using SaraLemus._2024.PruebaTecnica.EN;

namespace SaraLemus._2024.PruebaTecnica.Controllers
{
    public class ProductoController : Controller
    {
        private readonly ProductoBL _productoBL;

        public ProductoController(ProductoBL productoBL)
        {
            _productoBL = productoBL;
        }

        public IActionResult Index()
        {
            var productos = _productoBL.ObtenerProductos();
            return View(productos);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Producto producto)
        {
            if (string.IsNullOrEmpty(producto.Nombre))
            {
                ModelState.AddModelError("Nombre", "El nombre del producto es obligatorio.");
                return View(producto);
            }

            _productoBL.AgregarProducto(producto);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int id)
        {
            var producto = _productoBL.ObtenerProductoPorId(id);
            if (producto == null)
            {
                return NotFound();
            }
            return View(producto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Producto producto)
        {
            if (string.IsNullOrEmpty(producto.Nombre))
            {
                ModelState.AddModelError("Nombre", "El nombre del producto es obligatorio.");
                return View(producto);
            }

            _productoBL.ActualizarProducto(producto);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id)
        {
            var producto = _productoBL.ObtenerProductoPorId(id);
            if (producto == null)
            {
                return NotFound();
            }
            return View(producto);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _productoBL.EliminarProducto(id);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var producto = _productoBL.ObtenerProductoPorId(id);
            if (producto == null)
            {
                return NotFound();
            }
            return View(producto);
        }
    }
}
