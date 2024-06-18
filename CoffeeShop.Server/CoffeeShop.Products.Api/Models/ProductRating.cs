using CoffeeShop.DataAccess.Common;

namespace CoffeeShop.Products.Api.Models
{
    public class ProductRating : BaseEntity
    {
        public int Stars { get; set; }
        public int? ProductId { get; set; }
        public virtual Product Product { get; set; }
    }
}