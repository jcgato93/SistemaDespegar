using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel1.Entity
{
    public class Cuartos
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string NumeroHabitacion { get; set; }

        [Required]
        public int  TipoDeCuartoId { get; set; }

        [Required]
        public int StatusId { get; set; }


        public virtual ICollection<Reservas> Reservas { get; set; }

        [ForeignKey(nameof(TipoDeCuartoId))]
        public virtual TipoDeCuarto TipoDeCuarto { get; set; }

        [ForeignKey(nameof(StatusId))]
        public virtual Status Status { get; set; }
    }
}
