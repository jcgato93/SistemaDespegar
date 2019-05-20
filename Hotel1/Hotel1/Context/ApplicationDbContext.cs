using Hotel1.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel1.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        public DbSet<Cuartos> Cuartos { get; set; }
        public DbSet<Reservas> Reservas { get; set; }
        public DbSet<Status> Status { get; set; }
        public DbSet<TipoDeCuarto> TipoDeCuartos { get; set; }
    }
}
