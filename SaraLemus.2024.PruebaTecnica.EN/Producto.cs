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
        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "El campo Nombre es obligatorio")]
        [MaxLength(50, ErrorMessage = "El campo Nombre no puede tener mas de 50 caracteres")]
        public string Nombre { get; set; }
        [Display(Name = "Precio")]
        [Required(ErrorMessage = "El campo Precio es obligatorio")]
        [MaxLength(50, ErrorMessage = "El campo Precio no puede tener mas de 50 caracteres")]
        public decimal Precio { get; set; }
        
        public int IdCategoria { get; set; }
    }
}
