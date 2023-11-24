using Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Data
{
    public class CatalogDBContext : DbContext
    {
        public CatalogDBContext(DbContextOptions<CatalogDBContext> options) : base(options) { }

        public DbSet<Category> Categories { get; set; } = null!;
    }
}
