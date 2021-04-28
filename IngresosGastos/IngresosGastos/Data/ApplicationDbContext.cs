using IngresosGastos.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace IngresosGastos.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() : base("DefaultConnection")
        {

        }


        public DbSet<IngresosGastosMMu> IngresosGastos { get; set; }
    }
}