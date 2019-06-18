using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace FDMC.Domains
{
    public class FDMCContext : DbContext
    {
        public FDMCContext (DbContextOptions<FDMCContext> options)
            : base(options)
        {
        }

        public DbSet<FDMC.Domains.Cat> Cat { get; set; }
    }
}
