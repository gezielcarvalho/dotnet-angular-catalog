using Backend.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.Options;
using System.Threading;

namespace Backend.Data
{
    public class CatalogDBContext : DbContext
    {
        public CatalogDBContext(DbContextOptions<CatalogDBContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Category> Categories { get; set; } = null!;

        public override int SaveChanges()
        {
            var entries = ChangeTracker.Entries().Where(e => e.Entity is Category && (
                           e.State == EntityState.Added
                                          || e.State == EntityState.Modified));
            foreach (var entry in entries)
            {
                if (entry != null && entry!.Entity is Category)
                {
                    // if entity is added, set created date
                    if (entry.State == EntityState.Added)
                    {
                        ((Category)entry.Entity).CreatedAt = DateTime.Now;
                    }
                    else if (entry.State == EntityState.Modified)
                    {
                        ((Category)entry.Entity).UpdatedAt = DateTime.Now;
                        // keep created date unchanged
                        entry.Property("CreatedAt").IsModified = false;
                    }
                }
            }
            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            var entries = ChangeTracker.Entries().Where(e => e.Entity is Category && (
                             e.State == EntityState.Added || e.State == EntityState.Modified)); ;
            // set updated date for modified entries
            foreach (var entry in entries)
            {
                if (entry != null && entry!.Entity is Category)
                {
                    // if entity is added, set created date
                    if (entry.State == EntityState.Added)
                    {
                        ((Category)entry.Entity).CreatedAt = DateTime.Now;
                    }
                    else if (entry.State == EntityState.Modified)
                    {
                        ((Category)entry.Entity).UpdatedAt = DateTime.Now;
                        // keep created date unchanged
                        entry.Property("CreatedAt").IsModified = false;
                    }
                }
            }
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category
                {
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    Id = 1,
                    Name = "Books"
                },
                new Category
                {
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    Id = 2,
                    Name = "Movies"
                },
                new Category
                {
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    Id = 3,
                    Name = "Music"
                }
            );
        }
    }
}
