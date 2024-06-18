using CoffeeShop.DataAccess.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoffeeShop.Products.Api.Models
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public CoffeeCategories Category { get; set; }
        public string Description { get; set; }
        [Column(TypeName = "decimal(8, 2)")]
        public decimal Price { get; set; }
        public int? SupplierId { get; set; }
        public virtual Supplier Supplier { get; set; }
        public virtual List<ProductRating> ProductRatings { get; set; }
    }

    public enum CoffeeCategories
    {
        // Coffee
        WholeBean,       // Зерновой кофе (Whole bean coffee)
        Ground,          // Молотый кофе (Ground coffee)
        Instant,         // Растворимый кофе (Instant coffee)
        Pods,            // Кофе в капсулах (Coffee pods)
        Specialty,       // Специальный кофе, например, с ароматами или особыми добавками (Specialty coffee, e.g., flavored or premium blends)

        // Accessories
        CoffeeMakers,    // Кофеварки (Coffee makers)
        Grinders,        // Кофемолки (Coffee grinders)
        Mugs,            // Кружки (Coffee mugs)
        Filters,         // Фильтры для кофе (Coffee filters)

        // Food items
        Pastries,        // Выпечка 
        Snacks,          // Закуски
        Syrups,          // Сиропы для кофе
        MilkAlternatives,// Альтернативы молоку (миндальное, соевое и т.д.) (Milk alternatives (e.g., almond, soy))

        // Merchandise
        Merchandise,     // Одежда и аксессуары с логотипом магазина (Milk alternatives (e.g., almond, soy))

        // Other
        Gifts,           // Подарочные наборы (Gift sets)
        Subscriptions    // Подписка на кофе (Coffee subscription services)
    }
}
