using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Despegar.Entity
{
    public class Reserva
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

        [Required]
        public string Hotel { get; set; }

    }
}
