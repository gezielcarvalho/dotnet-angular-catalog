using Backend.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Backend.Data
{
    public class CatalogDBContext : DbContext
    {
        public CatalogDBContext(DbContextOptions<CatalogDBContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Category> Categories { get; set; } = null!;
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
