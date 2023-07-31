using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using LeagueApp_xamarin_backend.Models;

using Microsoft.Extensions.Logging;

namespace LeagueApp_xamarin_backend.Data
{
    public class MyDbContext : DbContext
    {
        private readonly ILogger<MyDbContext> _logger;
        public MyDbContext(DbContextOptions<MyDbContext> options, ILogger<MyDbContext> logger) : base(options)
        {
            _logger = logger;
        }

        public DbSet<Item> Items { get; set; }
        public DbSet<User> Users { get; set; }

        // Add other DbSets for other entities as needed
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Specify the unique constraint for the Description property
            modelBuilder.Entity<Item>()
                .HasIndex(i => i.Description)
                .IsUnique();
                        // Specify the unique constraint for the Username property
            modelBuilder.Entity<User>()
                .HasIndex(u => u.Username)
                .IsUnique();

            // Specify the unique constraint for the Email property
            modelBuilder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();
        }

        public List<Item> GetItems()
        {
            return Items.ToList();
        }

        public void SignupUser(User user)
        {
            Users.Add(user);
            SaveChanges();
        }

    }
}