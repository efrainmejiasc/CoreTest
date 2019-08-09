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
        { }

        public EngineContext(DbContextOptions<EngineContext>options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<UserApi>(entity => {entity.HasIndex(e => e.Email).IsUnique(); });
            builder.Entity<Company>(entity => { entity.HasIndex(e => e.Email).IsUnique(); });
        }

        public DbSet<UserApi> UserApi { get; set; }

        public DbSet<Company> Company { get; set; }

        public DbSet<Subsidiary> Subsidiary { get; set; }
    }
}
