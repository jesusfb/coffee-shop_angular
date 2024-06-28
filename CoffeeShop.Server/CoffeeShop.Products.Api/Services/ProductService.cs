using AutoMapper;
using CoffeeShop.Products.Api.Helpers;
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

        //public async Task<List<string>> GetCategoryTypes()
        //{
        //    var categoryNames = Enum.GetNames(typeof(CategoryName)).ToList();
        //    return await Task.FromResult(categoryNames);
        //}

        //public async Task<List<CategoryDto>> GetCategories()
        //{
        //    var allItems = new List<CategoryDto>();

        //    foreach (CategoryName category in Enum.GetValues(typeof(CategoryName)))
        //    {
        //        var itemsByCategory = CategoryItemHelper.GetCategoryItemsByType(category);
        //        var stringItems = new List<string>();

        //        foreach (var item in itemsByCategory)
        //        {
        //            stringItems.Add(Enum.GetName(item) ?? string.Empty);
        //        }

        //        allItems.Add(new CategoryDto 
        //        { 
        //            Name = Enum.GetName(category) ?? string.Empty,
        //            Subcategories = stringItems
        //        }) ;
        //    }

        //    return allItems;
        //}

        public async Task<List<CategoryDto>> GetCategories()
        {
            var allItems = Enum.GetValues(typeof(CategoryName))
                .Cast<CategoryName>()
                .Select(category => new CategoryDto
                { 
                    Name = Enum.GetName(typeof(CategoryName), category) ?? string.Empty,
                    Subcategories = CategoryItemHelper.GetCategoryItemsByType(category)
                    .Select(item => Enum.GetName(typeof(CategoryItem), item) ?? string.Empty)
                    .ToList()
                })
                .ToList();

            return await Task.FromResult(allItems);
        }
    }
}
