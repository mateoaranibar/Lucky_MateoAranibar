using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SegundoParcial.Models
{
    public class Suerte
    {
        [Key]
        public int SuerteId { get; set; }
        
        [Required(AllowEmptyStrings = false, ErrorMessage ="(0) es requerido")]
        [StringLength(200, MinimumLength = 5, ErrorMessage = "Debe de tener entre 5 y 200 carasteres")]
        public string Detalle { get; set; }

        [Url]
        [StringLength(100, MinimumLength = 10, ErrorMessage = "Debe de tener entre 10 y 100 carasteres")]
        public string Enlace { get; set; }

    }
}
