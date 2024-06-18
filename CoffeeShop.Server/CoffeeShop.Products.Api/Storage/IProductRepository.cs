using CoffeeShop.DataAccess.Common;
using CoffeeShop.Products.Api.Models;

namespace CoffeeShop.Products.Api.Storage
{
    public interface IProductRepository : IBaseRepository<Product>
    {
        Task<Product> GetProductAsync(int id);
        Task<List<Product>> GetProductsAsync();
        Task<List<Product>> GetProductsWithoutRatingsAsync();
        Task UpdateProductWithRelatedEntitiesAsync(Product product);

        Task<List<CoffeeCategories>> GetCategories();
    }
}
