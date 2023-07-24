using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using LeagueApp_xamarin_backend.Models;

namespace LeagueApp_xamarin_backend.Data
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {
        }

        public DbSet<Item> Items { get; set; }
        // Add other DbSets for other entities as needed
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Specify the unique constraint for the Description property
            modelBuilder.Entity<Item>()
                .HasIndex(i => i.Description)
                .IsUnique();
        }
    
    }
}