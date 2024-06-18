using AutoMapper;
using CoffeeShop.Products.Api.Models;
using CoffeeShop.Products.Api.Models.Dto;
using CoffeeShop.Products.Api.Storage;

namespace CoffeeShop.Products.Api.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository productRepository;
        private readonly IMapper mapper;
        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            this.productRepository = productRepository;
            this.mapper = mapper;
        }

        public async Task<ProductDto> GetProductAsync(int id)
        {
            var product = await productRepository.GetProductAsync(id);
            return mapper.Map<ProductDto>(product);
        }

        public async Task<List<ProductDto>> GetProductsAsync()
        {
            var products = await productRepository.GetProductsAsync();
            return mapper.Map<List<ProductDto>>(products);
        }

        public async Task<List<ProductDto>> GetProductsWithoutRatingsdAsync()
        {
            var products = await productRepository.GetProductsWithoutRatingsAsync();
            return mapper.Map<List<ProductDto>>(products);
        }

        public async Task<int> CreateAsync(ProductDto createProductRequestModel)
        {
            if (createProductRequestModel == null)
            {
                throw new ArgumentNullException(nameof(createProductRequestModel));
            }

            var product = mapper.Map<Product>(createProductRequestModel);
            var result = await productRepository.InsertAsync(product);
            return result.Id;
        }

        public async Task UpdateProductAsync(ProductDto editProductRequestModel)
        {
            var product = mapper.Map<Product>(editProductRequestModel);
            await productRepository.UpdateAsync(product);
        }

        public async Task UpdateProductWithRelatedEntitiesAsync(ProductDto editProductRequestModel)
        {
            var product = mapper.Map<Product>(editProductRequestModel);
            await productRepository.UpdateProductWithRelatedEntitiesAsync(product);
        }

        public async Task DeleteProductAsync(int id)
        {
            var product = await productRepository.GetProductAsync(id);
            await productRepository.DeleteAsync(product);
        }

        public async Task<List<CoffeeCategories>> GetCategories()
        {
            return await productRepository.GetCategories();
        }
    }
}
