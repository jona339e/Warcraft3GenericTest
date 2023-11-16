
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;
using Warcraft3GenericTest.Models;

namespace Warcraft3GenericTest.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        // DbSet properties for your entities
        public DbSet<Race> Races { get; set; }
        public DbSet<Building> Buildings { get; set; }
        public DbSet<Unit> Units { get; set; }
        public DbSet<Faction> Factions { get; set; }

        // Add DbSet properties for other entities if needed

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure your entity relationships, constraints, etc.

            modelBuilder.Entity<Race>()
                .HasMany(r => r.Buildings)
                .WithOne(b => b.Race)
                .HasForeignKey(x => x.RaceId)
                .OnDelete(DeleteBehavior.Cascade); // Delete Buildings on Race Deletion

            modelBuilder.Entity<Race>()
                .HasMany(r => r.Units)
                .WithOne(u => u.Race)
                .HasForeignKey(u => u.RaceId)
                .OnDelete(DeleteBehavior.Cascade); // Delete Units on Race Deletion

            modelBuilder.Entity<Race>()
                .HasMany(r => r.Factions)
                .WithMany(f => f.Races)
                .UsingEntity(j => j.ToTable("RaceFactions"));

            // Building to Unit
            modelBuilder.Entity<Building>()
                .HasMany(r => r.Units)
                .WithOne(u => u.Building)
                .HasForeignKey(u => u.BuildingId)
                .OnDelete(DeleteBehavior.NoAction); // Do not delete Race if Building is deleted

            // Building to Race
            modelBuilder.Entity<Building>()
                .HasOne(b => b.Race)
                .WithMany(r => r.Buildings)
                .HasForeignKey(b => b.RaceId)
                .OnDelete(DeleteBehavior.NoAction); // Do not delete Race if Building is deleted

            // Unit to Race
            modelBuilder.Entity<Unit>()
                .HasOne(u => u.Race)
                .WithMany(r => r.Units)
                .HasForeignKey(u => u.RaceId)
                .OnDelete(DeleteBehavior.NoAction); // Do not delete Race if Unit is deleted

            // Unit to Building
            modelBuilder.Entity<Unit>()
                .HasOne(u => u.Building)
                .WithMany(b => b.Units)
                .HasForeignKey(u => u.BuildingId)
                .OnDelete(DeleteBehavior.NoAction); // Do not delete Building if Unit is deleted


        }
    }
}
