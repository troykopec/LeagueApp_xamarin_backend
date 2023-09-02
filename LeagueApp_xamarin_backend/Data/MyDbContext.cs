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
        public DbSet<Team> Teams { get; set; }
        public DbSet<League> Leagues { get; set; }

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
            modelBuilder.Entity<User>()
                .Property(u => u.CreatedAt)
                .HasColumnType("datetime");
            modelBuilder.Entity<User>()
                .Property(u => u.UpdatedAt)
                .HasColumnType("datetime");

            // Configure TPT for League and its derived classes
            modelBuilder.Entity<League>().ToTable("Leagues"); // Base table
            modelBuilder.Entity<SoccerLeague>().ToTable("SoccerLeagues"); // Soccer-specific table
            modelBuilder.Entity<BasketballLeague>().ToTable("BasketballLeagues"); // Basketball-specific table
            modelBuilder.Entity<NicheLeague>().ToTable("NicheLeagues"); // Niche-specific table
                    
            modelBuilder.Entity<League>()
                .Property(u => u.StartDate)
                .HasColumnType("datetime");
            modelBuilder.Entity<League>()
                .Property(u => u.EndDate)
                .HasColumnType("datetime");
            modelBuilder.Entity<League>()
                .Property(u => u.RegistrationStartDate)
                .HasColumnType("datetime");
            modelBuilder.Entity<League>()
                .Property(u => u.RegistrationEndDate)
                .HasColumnType("datetime");

            modelBuilder.Entity<Team>()
                .HasOne(team => team.League)
                .WithMany(league => league.Teams)
                .HasForeignKey(team => team.LeagueId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Team>()
                .HasOne(team => team.TeamLeader)
                .WithMany()
                .HasForeignKey(team => team.TeamLeaderId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<League>()
                .HasOne<User>() // Replace 'User' with your actual user entity type
                .WithMany()     // Depending on your relationship, you might need to specify the navigation property in WithMany()
                .HasForeignKey(league => league.OrganizerId)
                .OnDelete(DeleteBehavior.Restrict); // Or other DeleteBehavior as needed
            
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
        
        public bool IsEmailTaken(string email)
        {
            return Users.Any(u => u.Email == email);
        }
        public void CreateLeague(League league)
        {
            Leagues.Add(league);
            SaveChanges();
        }

        public bool IsUsernameTaken(string username)
        {
            return Users.Any(u => u.Username == username);
        }

    }
}