using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel1.Entity
{
    public class Status
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string descripcion { get; set; }

        public virtual ICollection<Cuartos> Cuartos { get; set; }
    }
}
