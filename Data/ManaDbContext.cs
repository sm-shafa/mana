using ManaCoreWebApplication.Models;
using Microsoft.EntityFrameworkCore;

namespace ManaCoreWebApplication.Data
{
    public class ManaDbContext : DbContext, IDbContext
    {
        public ManaDbContext(DbContextOptions<ManaDbContext> options) : base(options)
        {
            Database.Migrate();
            // Or Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .HasMany<Product>(g => g.Products)
                .WithOne(s => s.Category)
                .HasForeignKey(s => s.CategoryId);



            //seed
            // modelBuilder.Entity<Route>().HasData(new Route(1));
            // modelBuilder.Entity<Route>().HasData(new Route(2));
        }
    }
}
