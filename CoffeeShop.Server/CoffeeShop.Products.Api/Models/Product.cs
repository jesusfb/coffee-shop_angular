using CoffeeShop.DataAccess.Common;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;

namespace CoffeeShop.Products.Api.Models
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public CategoryName? CategoryName { get; set; } = Models.CategoryName.Others;
        public CategoryItem CategoryItem { get; set; }
        public string Description { get; set; }
        [Column(TypeName = "decimal(8, 2)")]
        public decimal Price { get; set; }
        public int? SupplierId { get; set; }
        public virtual Supplier Supplier { get; set; }
        public virtual List<ProductRating> ProductRatings { get; set; }
    }

    public enum CategoryName
    {
        Coffee,
        Accessories,
        FoodItems,
        Others
    }

    public enum CategoryItem
    {
        [CategoryItem(CategoryName.Coffee)]
        WholeBean,      
        [CategoryItem(CategoryName.Coffee)]
        Ground,         
        [CategoryItem(CategoryName.Coffee)]
        Instant,        
        [CategoryItem(CategoryName.Coffee)]
        Pods,           
        [CategoryItem(CategoryName.Coffee)]
        Specialty,      

        [CategoryItem(CategoryName.Accessories)]
        CoffeeMakers,   
        [CategoryItem(CategoryName.Accessories)]
        Grinders,       
        [CategoryItem(CategoryName.Accessories)]
        Mugs,           
        [CategoryItem(CategoryName.Accessories)]
        Filters,        

        [CategoryItem(CategoryName.FoodItems)]
        Pastries,       
        [CategoryItem(CategoryName.FoodItems)]
        Snacks,         
        [CategoryItem(CategoryName.FoodItems)]
        Syrups,         
        [CategoryItem(CategoryName.FoodItems)]
        MilkAlternatives,

        [CategoryItem(CategoryName.Others)]
        Merchandise,     
        [CategoryItem(CategoryName.Others)]
        Subscriptions
    }

    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
    public class CategoryItemAttribute : Attribute
    {
        public CategoryName CategoryType { get; }

        public CategoryItemAttribute(CategoryName category)
        {
            CategoryType = category;
        }
    }

    //public static class CategoryItemHelper
    //{
    //    public static CategoryName GetCategoryTypeByItem(this CategoryItem categoryItem)
    //    {
    //        var fieldInfo = categoryItem.GetType().GetField(categoryItem.ToString());
    //        var attribute = fieldInfo.GetCustomAttributes(typeof(CategoryAttribute), false).FirstOrDefault() as CategoryItemAttribute;
    //        return attribute?.CategoryType ?? CategoryName.Others;
    //    }
    //}
}


