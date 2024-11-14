using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
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
    public class RpgMenagerDbContext: IdentityDbContext
    {
        public RpgMenagerDbContext(DbContextOptions<RpgMenagerDbContext> options): base(options) { }
        public DbSet<PC> PCs { get; set; }
        public DbSet<NPC> NPCs { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<IndexOfStatistic> IndexsOfStatistic { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Statistic> Statistics { get; set; }
        public DbSet<IndexOfItem> IndexsOfItems { get; set; }

        public DbSet<Card> Cards { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<PC>()
                .HasOne(PC => PC.Player)
                .WithMany(p => p.PlayerCharacters)
                .HasForeignKey(PC => PC.PlayerId);

            modelBuilder.Entity<Statistic>()
                .Property(s => s.statisticsEnum)
                .HasConversion<string>();

            modelBuilder.Entity<Character>()
                .HasMany(c => c.IndexOfStatistic)  // Character ma wiele IndexOfStatistic
                .WithOne(l => l.Character)
                .HasForeignKey(l => l.CharacterId)     // IndexOfStatistic przechowuje ListId jako klucz obcy
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Character>().HasMany(c => c.Cards)
                .WithOne(a => a.Character).HasForeignKey(a => a.CharacterID).OnDelete(DeleteBehavior.Cascade);
           

            modelBuilder.Entity<Character>()
                .HasMany(c => c.IndexOfItem)  
                .WithOne(l => l.Character)  
                .HasForeignKey(l => l.CharacterId)     
                .OnDelete(DeleteBehavior.Cascade);

            
            modelBuilder.Entity<Item>()
                .HasMany(i => i.IndexOfStatistic)  // Item może mieć wiele IndexOfStatistic
                .WithOne(l => l.Item)       // Każda IndexOfStatistic ma jednego właściciela typu Item
                .HasForeignKey(l => l.ItemId)     // IndexOfStatistic przechowuje ListId jako klucz obcy
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Statistic>()
                .HasOne(s => s.IndexOfStatistic)
                .WithMany(L => L.MainList)
                .HasForeignKey(s => s.ListId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Item>()
                .HasOne(i => i.IndexOfItems)
                .WithMany(l => l.MainList)
                .HasForeignKey(s =>s.ListId)
                .OnDelete(DeleteBehavior.Cascade);
                

        }

    }
}
