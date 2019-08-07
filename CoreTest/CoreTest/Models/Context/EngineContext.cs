using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreTest.Models.Context
{
    public class EngineContext : DbContext
    {
        public EngineContext()
        {
        }

        public EngineContext(DbContextOptions<EngineContext> options) : base(options)
        {
        }

        public DbSet<Company> Company { get; set; }
        public DbSet<Subsidiary> Subsidiary { get; set; }
    }
}
