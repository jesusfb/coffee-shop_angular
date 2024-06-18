namespace CoffeeShop.Products.Api.Models.Dto
{
    public class ProductRatingDto
    {
        public int Id { get; set; }
        public int Stars { get; set; }
        public int? ProductId { get; set; }
      //  public ProductDto Product { get; set; }
    }
}
