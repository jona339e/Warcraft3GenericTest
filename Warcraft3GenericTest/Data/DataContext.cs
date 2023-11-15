
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;
using Warcraft3GenericTest.Models;

namespace Warcraft3GenericTest.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options): base(options) { }

        // DbSet properties for your entities
        public DbSet<Race> Races { get; set; }
        public DbSet<Building> Buildings { get; set; }
        public DbSet<Unit> Units { get; set; }

        // Add DbSet properties for other entities if needed

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure your entity relationships, constraints, etc.
        }
    }
}
