using CoffeeShop.Products.Api.Models;
using CoffeeShop.Products.Api.Models.Dto;

namespace CoffeeShop.Products.Api.Services
{
    public interface IProductService
    {
        Task<ProductDto> GetProductAsync(int id);
        Task<List<ProductDto>> GetProductsAsync();
        Task<List<ProductDto>> GetProductsWithoutRatingsdAsync();
        Task<int> CreateAsync(ProductDto productDto);
        Task UpdateProductAsync(ProductDto productDto);
        Task UpdateProductWithRelatedEntitiesAsync(ProductDto productDto);
        Task DeleteProductAsync(int id);
        Task<List<CoffeeCategories>> GetCategories();
    }
}
