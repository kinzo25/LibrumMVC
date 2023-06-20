using CarpeLibrumRazor.Models;
using Microsoft.EntityFrameworkCore;

namespace CarpeLibrumRazor.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Category> Categories { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Fantasy", DisplayOrder = 1 },
                new Category { Id = 2, Name = "Action", DisplayOrder = 2 },
                new Category { Id = 3, Name = "Crime", DisplayOrder = 3 },
                new Category { Id = 4, Name = "Horror", DisplayOrder = 4 });

        }
    }
}
