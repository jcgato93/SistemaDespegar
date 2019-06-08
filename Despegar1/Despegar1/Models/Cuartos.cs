using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Despegar1.Models
{
    public class Cuartos
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string NumeroHabitacion { get; set; }

        [Required]
        public string TipoDeCuarto { get; set; }

        [Required]
        public string Status { get; set; }

        [Required]
        public int Precio { get; set; }

        public string Hotel { get; set; }
    }
}
