namespace CoffeeShop.Products.Api.Models.Dto
{
    public class SupplierDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string State { get; set; }
      //  public List<ProductDto> Products { get; set; }
        public int? ProductsCount { get; set; }
    }
}
