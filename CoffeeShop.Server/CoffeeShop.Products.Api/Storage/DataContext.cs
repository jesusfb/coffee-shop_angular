using CoffeeShop.Products.Api.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;

namespace CoffeeShop.Products.Api.Storage
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> opts)
            : base(opts)
        {
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<ProductRating> ProductRatings { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // optionsBuilder.UseLazyLoadingProxies();
        }

        public override async Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            //CreateTimestamps();
            UpdateTimestamps();
            return await base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        private void UpdateTimestamps()
        {
            var entities = ChangeTracker.Entries();
            var currentTime = DateTime.UtcNow;

            foreach (var entity in entities)
            {
                if (entity.State == EntityState.Modified)
                {
                    entity.Property("UpdatedAt").CurrentValue = currentTime;
                }
            }
        }

        private void CreateTimestamps()
        {
            var entities = ChangeTracker.Entries()
                .Where(e => e.State == EntityState.Added);

            var currentTime = DateTime.UtcNow.ToString();

            foreach (var entity in entities)
            {
                entity.Property("CreatedAt").CurrentValue = currentTime;
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>().HasMany(p => p.ProductRatings)
            .WithOne(r => r.Product).OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Product>().HasOne(p => p.Supplier)
            .WithMany(s => s.Products).OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Product>().Property(p => p.CategoryName).HasConversion<string>();

            modelBuilder.Entity<Supplier>().HasData(
                new Supplier { Id = 1, Name = "Best Beans", City = "Seattle", State = "WA" },
                new Supplier { Id = 2, Name = "Coffee Palace", City = "San Francisco", State = "CA" },
                new Supplier { Id = 3, Name = "Java Central", City = "New York", State = "NY" }
            );

            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, Name = "Ethiopian Whole Bean", CategoryName = CategoryName.Coffee, CategoryItem = CategoryItem.WholeBean, Description = "Rich and aromatic Ethiopian beans.", Price = 15.99M, SupplierId = 1 },
                new Product { Id = 2, Name = "Italian Ground Coffee", CategoryName = CategoryName.Coffee, CategoryItem = CategoryItem.Ground, Description = "Smooth and strong Italian ground coffee.", Price = 12.50M, SupplierId = 2 },
                new Product { Id = 3, Name = "Instant Coffee Delight", CategoryName = CategoryName.Coffee, CategoryItem = CategoryItem.Instant, Description = "Convenient and tasty instant coffee.", Price = 8.99M, SupplierId = 3 },
                new Product { Id = 4, Name = "Espresso Coffee Pods", CategoryName = CategoryName.Coffee, CategoryItem = CategoryItem.Pods, Description = "Rich espresso coffee pods.", Price = 9.99M, SupplierId = 1 },
                new Product { Id = 5, Name = "Organic Coffee Maker", CategoryName = CategoryName.Accessories, CategoryItem = CategoryItem.CoffeeMakers, Description = "Eco-friendly coffee maker.", Price = 55.00M, SupplierId = 2 },
                new Product { Id = 6, Name = "Monthly Coffee Subscription", CategoryItem = CategoryItem.Subscriptions, Description = "Receive a new coffee each month.", Price = 29.99M, SupplierId = 1 },
                new Product { Id = 7, Name = "Premium Coffee Subscription", CategoryItem = CategoryItem.Subscriptions, Description = "Premium coffee delivered monthly.", Price = 49.99M, SupplierId = 2 },
                new Product { Id = 8, Name = "Coffee Lover's Subscription", CategoryItem = CategoryItem.Subscriptions, Description = "Exclusive blends for coffee lovers.", Price = 39.99M, SupplierId = 3 }
            );

            modelBuilder.Entity<ProductRating>().HasData(
                new ProductRating { Id = 1, Stars = 5, ProductId = 1 },
                new ProductRating { Id = 2, Stars = 4, ProductId = 2 },
                new ProductRating { Id = 3, Stars = 3, ProductId = 3 },
                new ProductRating { Id = 4, Stars = 5, ProductId = 4 },
                new ProductRating { Id = 5, Stars = 4, ProductId = 5 },
                new ProductRating { Id = 6, Stars = 5, ProductId = 6 },
                new ProductRating { Id = 7, Stars = 4, ProductId = 7 },
                new ProductRating { Id = 8, Stars = 5, ProductId = 8 }
            );
        }
    }
}
