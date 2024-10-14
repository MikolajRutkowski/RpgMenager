using Microsoft.EntityFrameworkCore;
using RpgMenager.Domain.Entities;
using RpgMenager.Domain.Entities.Abstract;
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
        public DbSet<IndexOfStatistic> ListOfStatistics { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Statistic> Statistics { get; set; }
        public DbSet<IndexOfItem> listOfItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PC>()
                .HasOne(PC => PC.Player)
                .WithMany(p => p.PlayerCharacters)
                .HasForeignKey(PC => PC.PlayerId);
            modelBuilder.Entity<Statistic>()
                .Property(s => s.statisticsEnum)
                .HasConversion<string>();
            modelBuilder.Entity<Statistic>()
                .HasOne(s => s.IndexOfStatistic)
                .WithMany(L => L.MainList)
                .HasForeignKey(s => s.ListId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Character>()
                .HasMany(c => c.ListOfIndexStats)  // Character ma wiele IndexOfStatistic
                .WithOne(l => (Character)l.Owner)  // Każda IndexOfStatistic ma jednego właściciela typu Character
                .HasForeignKey(l => l.OwnerId)     // IndexOfStatistic przechowuje OwnerId jako klucz obcy
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Character>()
                .HasMany(c => c.ListOfIndexItem)  
                .WithOne(l => (Character)l.Owner)  
                .HasForeignKey(l => l.OwnerId)     
                .OnDelete(DeleteBehavior.Cascade);

            
            modelBuilder.Entity<Item>()
                .HasMany(i => i.ListOfIndexStats)  // Item może mieć wiele IndexOfStatistic
                .WithOne(l => (Item)l.Owner)       // Każda IndexOfStatistic ma jednego właściciela typu Item
                .HasForeignKey(l => l.OwnerId)     // IndexOfStatistic przechowuje OwnerId jako klucz obcy
                .OnDelete(DeleteBehavior.Cascade);


        }

    }
}
