using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RpgMenager.Infrastructure.Persistence
{
    public class RpgMenagerDbContext: DbContext
    {
        public RpgMenagerDbContext(DbContextOptions<RpgMenagerDbContext> options): base(options) { }
        public DbSet<Domain.Entities.Character> Characters { get; set; }
        public DbSet<Domain.Entities.Item> Items { get; set; }

        public DbSet<Domain.Entities.Statistics> Statistics { get; set; }
        public DbSet<Domain.Entities.Player> Players { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }

        }
}
