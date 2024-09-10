using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using ProductServices.Models;

namespace ProductServices.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Product>().ToTable("Products").HasKey(p => p.Id);
        }
    }
}
