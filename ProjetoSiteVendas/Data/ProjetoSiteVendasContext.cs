using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjetoSiteVendas.Models;

namespace ProjetoSiteVendas.Data
{
    public class ProjetoSiteVendasContext : DbContext
    {
        public ProjetoSiteVendasContext (DbContextOptions<ProjetoSiteVendasContext> options)
            : base(options)
        {
        }

        public DbSet<ProjetoSiteVendas.Models.Department> Department { get; set; } = default!;
    }
}
