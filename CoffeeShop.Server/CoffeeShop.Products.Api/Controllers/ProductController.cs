using CoffeeShop.Products.Api.Models.Dto;
using CoffeeShop.Products.Api.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Cors;

namespace CoffeeShop.Products.Api.Controllers
{
    [Route("api/products")]
    //[Authorize(Roles = "Administrator")]
    [ApiController]
    [EnableCors("AllowSpecificOrigin")]
    //  [AutoValidateAntiforgeryToken]
    public class ProductController : Controller
    {
        private readonly IProductService productService;
        public ProductController(IProductService productService)
        {
            this.productService = productService;
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetProduct(int id)
        {
            try
            {
                var product = await productService.GetProductAsync(id);
                return Ok(product);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //https://localhost:5005/api/products?category=soccer&search=flat
        [HttpGet]
      //  [AllowAnonymous]
        public async Task<IActionResult> GetProducts(string category, string search)
        {
            try
            {
                var query = (await productService.GetProductsWithoutRatingsdAsync()).AsQueryable();

                //if (HttpContext.User.IsInRole("Administrator"))
                //{
                //    query = (await productService.GetProductsAsync()).AsQueryable();
                //}

                //if (!string.IsNullOrEmpty(category))
                //{
                //    string categoryLower = category.ToLower();
                //    query = query.Where(x => x.CoffeeCategory.ToLower().Contains(categoryLower));
                //}

                //if (!string.IsNullOrEmpty(search))
                //{
                //    string searchLower = search.ToLower();
                //    query = query.Where(x => x.Name.ToLower().Contains(searchLower) || x.Description.ToLower().Contains(searchLower));
                //}

                return Ok(query);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(ProductDto productDto)
        {
            if (ModelState.IsValid)
            {
                return Ok(await productService.CreateAsync(productDto));
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProductAsync(ProductDto productDto)
        {
            if (ModelState.IsValid)
            {
                await productService.UpdateProductAsync(productDto);
                return Ok();
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpPut("complete-supplier-and-product-update")]
        public async Task<IActionResult> UpdateProductWithRelatedEntitiesAsync(ProductDto productDto)
        {
            if (ModelState.IsValid)
            {
                await productService.UpdateProductWithRelatedEntitiesAsync(productDto);
                return Ok();
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpPatch]
        public async Task<IActionResult> PatchProductUpdateAsync([FromBody] JsonPatchDocument<ProductDto> jsonPatch)
        {
            if (jsonPatch == null)
            {
                return BadRequest("Json patch document is null.");
            }

            var product = new ProductDto();

            jsonPatch.ApplyTo(product);

            if (TryValidateModel(product))
            {
                await productService.UpdateProductWithRelatedEntitiesAsync(product);
                return Ok();
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductAsync(int id)
        {
            try
            {
                await productService.DeleteProductAsync(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("categories")]
        [AllowAnonymous]
        public async Task<IActionResult> GetCategories()
        {
            try
            {
                var categories = await productService.GetCategories();
                return Ok(categories);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
