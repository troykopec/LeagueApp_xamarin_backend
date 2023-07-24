using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using eZ_Leagues.Models;

namespace eZ_Leagues.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Item> Items { get; set; }
        // Add other DbSets for other entities as needed
    }
}