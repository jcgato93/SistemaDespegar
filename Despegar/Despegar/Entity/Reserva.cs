using Despegar.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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

        public int Precio { get; set; }

        [Required]
        public DateTime FechaReserva { get; set; }

        [Required]
        public int DiasReserva { get; set; }

        [Required]
        public int CantidadPersonas { get; set; }

        [Required]
        public string ClienteId { get; set; }

        [Required]
        public int IdentificacionCliente { get; set; }

        [Required]
        public string Hotel { get; set; }

        [Required]
        public string Status { get; set; }

        [Required]
        public int ReservaId { get; set; }

        [Required]
        [Display(Name ="Total a Pagar")]
        public int TotalPago { get; set; }

        [Required]
        [Display(Name ="Fecha de Vencimiento de la Tarjeta")]
        public DateTime FechaVencimiento { get; set; }

        [Required]
        public string CVC { get; set; }


        [ForeignKey(nameof(ClienteId))]
        public virtual IdentityUser Cliente { get; set; }

       
    }
}
