﻿using Microsoft.EntityFrameworkCore;
using Prijavnice.Models;
using System.Collections.Generic;

namespace Prijavnice.Data
{
    public class PrijavniceContext:DbContext

    {
        public PrijavniceContext(DbContextOptions<PrijavniceContext> opcije) : base(opcije)
        {
        }


        public DbSet<Vozilo> Vozila { get; set; }

        public DbSet<Utrka> Utrke { get; set; }

        public DbSet<Vozac> Vozaci {  get; set; }
    }

    
    
    
}
