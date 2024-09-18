using Microsoft.EntityFrameworkCore;
using RpgMenager.Domain.Entities;
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
        public DbSet<PC> PCs { get; set; }
        public DbSet<NPC> NPCs { get; set; }
        public DbSet<Item> Items { get; set; }

        public DbSet<Statistic> Statistics { get; set; }
        public DbSet<Player> Players { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Statistic>()
                .HasOne(s => s.Character)           
                .WithMany(c => c.ListOfStatistics)  
                .HasForeignKey(s => s.CharacterId);
            modelBuilder.Entity<Statistic>()
                .Property(s => s.statisticsEnum)
                .HasConversion<string>();
            modelBuilder.Entity<PC>()
                .HasOne(PC => PC.Player)
                .WithMany(p => p.PlayerCharacters)
                .HasForeignKey(PC => PC.PlayerId);
            modelBuilder.Entity<Item>()
                .HasOne(Item => Item.Character)
                .WithMany(c => c.ListOfItems)
                .HasForeignKey(Item => Item.CharacterId);
                
        }

        }
}
