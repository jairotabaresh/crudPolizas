using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Mvc.Models.Repositorio
{
    public class polizasContext : DbContext
    {
        public polizasContext () : base("name=DefaultConnection")
        { }
        public virtual DbSet<mvcPolizasModel> Poliza { get; set; }

    }
}