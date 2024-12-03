using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaraLemus._2024.PruebaTecnica.EN
{
    public class Producto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo 'Nombre' es obligatorio.")]
        [MaxLength(100, ErrorMessage = "El campo 'Nombre' no puede tener más de 100 caracteres.")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El campo 'Precio' es obligatorio.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "El 'Precio' debe ser mayor que cero.")]
        public decimal Precio { get; set; }

        [Required(ErrorMessage = "El campo 'Categoría' es obligatorio.")]
        public int IdCategoria { get; set; }
    }
}
