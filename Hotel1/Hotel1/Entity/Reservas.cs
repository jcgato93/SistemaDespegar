using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel1.Entity
{
    public class Reservas
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int CuartoId { get; set; }

        [Required]
        public DateTime FechaReserva { get; set; }

        [Required]
        public int DiasReserva { get; set; }

        [Required]
        public int CantidadPersonas { get; set; }

        [Required]
        public string NombreCliente { get; set; }

        [Required]
        public int IdentificacionCliente { get; set; }

        // Ativa 
        // Cancelado
        // Completado
        public string Status { get; set; }

  

        [ForeignKey(nameof(CuartoId))]
        public virtual Cuartos Cuartos { get; set; }
    }
}
