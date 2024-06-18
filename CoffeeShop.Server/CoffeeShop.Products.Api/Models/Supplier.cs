using CoffeeShop.DataAccess.Common;

namespace CoffeeShop.Products.Api.Models
{
    public class Supplier : BaseEntity
    {
        public string Name { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public virtual List<Product> Products { get; set; }
    }
}