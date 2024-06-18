using CoffeeShop.DataAccess.Common;
using CoffeeShop.Products.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace CoffeeShop.Products.Api.Storage
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        private readonly DataContext context;
        public ProductRepository(DataContext context) : base(context)
        {
            this.context = context;
        }

        public async Task<Product> GetProductAsync(int id) =>
            await context.Products
            .Include(p => p.Supplier)
            .Include(p => p.ProductRatings)
            .FirstOrDefaultAsync(p => p.Id == id);

        public async Task<List<Product>> GetProductsAsync() =>
            await context.Products
            .Include(p => p.Supplier)
            .Include(p => p.ProductRatings)
            .ToListAsync();


        public async Task<List<Product>> GetProductsWithoutRatingsAsync() =>
            await context.Products.Include(p => p.ProductRatings).ToListAsync();

        public async Task UpdateProductWithRelatedEntitiesAsync(Product product)
        {
            try
            {
                IncludeNavigationProperties(product);
                await UpdateAsync(product);
            }
            catch (Exception e)
            {
                //logger.LogError(e, "An error occurred while updating entity {EntityType}", typeof(TEntity).Name);
                throw new Exception(e.Message, e.InnerException);
            }
        }

        public async Task<List<CoffeeCategories>> GetCategories() =>
            await context.Products.Select(p => p.Category).Distinct().OrderBy(c => c).ToListAsync();
    }
}
