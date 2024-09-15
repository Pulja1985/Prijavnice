using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Prijavnice.Data
{
    public class PrijavniceContext:DbContext

    {
        public PrijavniceContext(DbContextOptions<PrijavniceContext> opcije) : base(opcije)
        {
        }


        public DbSet<Vozilo> Vozila { get; set; }
    }

    public class Vozilo
    {
    }
}
