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
            if (Database.IsInMemory())
            {
                Database.EnsureCreated();
            }
        }

        public DbSet<Category>? Categories { get; set; } = null!;
        public DbSet<Product>? Products { get; set; } = null!;
        public DbSet<Tag>? Tag { get; set; } = null!;
        public DbSet<Post>? Post { get; set; } = null!;
        public DbSet<PostTag>? PostTag { get; set; } = null!;

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
            modelBuilder.Entity<PostTag>()
            .HasKey(pt => new { pt.PostId, pt.TagId });

            modelBuilder.Entity<PostTag>()
                .HasOne(pt => pt.Post)
                .WithMany(p => p.PostTags)
                .HasForeignKey(pt => pt.PostId);

            modelBuilder.Entity<PostTag>()
                .HasOne(pt => pt.Tag)
                .WithMany(t => t.PostTags)
                .HasForeignKey(pt => pt.TagId);

            modelBuilder.Entity<Post>().HasData(
                new Post
                {
                    Id = 1,
                    Title = "Post 1",
                    Content = "Content 1"
                },
                new Post
                {
                    Id = 2,
                    Title = "Post 2",
                    Content = "Content 2"
                },
                new Post
                {
                    Id = 3,
                    Title = "Post 3",
                    Content = "Content 3"
                },
                new Post
                {
                    Id = 4,
                    Title = "Post 4",
                    Content = "Content 4"
                }
                );

            modelBuilder.Entity<Tag>().HasData(
                new Tag
                {
                    Id = 1,
                    TagName = "Tag 1"
                },
                new Tag
                {
                    Id = 2,
                    TagName = "Tag 2"
                },
                new Tag
                {
                    Id = 3,
                    TagName = "Tag 3"
                }
                );

            modelBuilder.Entity<PostTag>().HasData(
                new PostTag
                {
                    PostId = 1,
                    TagId = 1
                },
                new PostTag
                {
                    PostId = 1,
                    TagId = 2
                },
                new PostTag
                {
                    PostId = 2,
                    TagId = 2
                },
                new PostTag
                {
                    PostId = 2,
                    TagId = 3
                }
                );

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
                },
                new Category
                {
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    Id = 4,
                    Name = "Games"
                },
                new Category
                {
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    Id = 5,
                    Name = "Electronics"
                },
                new Category
                {
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    Id = 6,
                    Name = "Computers"
                },
                new Category
                {
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    Id = 7,
                    Name = "Home"
                },
                new Category
                {
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    Id = 8,
                    Name = "Garden"
                },
                new Category
                {
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    Id = 9,
                    Name = "Tools"
                },
                new Category
                {
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    Id = 10,
                    Name = "Grocery"
                },
                new Category
                {
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    Id = 11,
                    Name = "Health"
                },
                new Category
                {
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    Id = 12,
                    Name = "Beauty"
                },
                new Category
                {
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    Id = 13,
                    Name = "Toys"
                }
            );

            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    Id = 1,
                    Name = "Product 1",
                    Description = "Description 1",
                    Price = 1.99,
                    CategoryId = 1
                },
                new Product
                {
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    Id = 2,
                    Name = "Product 2",
                    Description = "Description 2",
                    Price = 2.99,
                    CategoryId = 2
                },
                new Product
                {
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    Id = 3,
                    Name = "Product 3",
                    Description = "Description 3",
                    Price = 3.99,
                    CategoryId = 3
                },
                new Product
                {
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    Id = 4,
                    Name = "Product 4",
                    Description = "Description 4",
                    Price = 4.99,
                    CategoryId = 4
                },
                new Product
                {
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    Id = 5,
                    Name = "Product 5",
                    Description = "Description 5",
                    Price = 5.99,
                    CategoryId = 5
                },
                new Product
                {
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    Id = 6,
                    Name = "Product 6",
                    Description = "Description 6",
                    Price = 6.99,
                    CategoryId = 6
                },
                new Product
                {
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    Id = 7,
                    Name = "Product 7",
                    Description = "Description 7",
                    Price = 7.99,
                    CategoryId = 7
                },
                new Product
                {
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    Id = 8,
                    Name = "Product 8",
                    Description = "Description 8",
                    Price = 8.99,
                    CategoryId = 8
                }
            );

        }


    }
}
