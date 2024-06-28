using CoffeeShop.Products.Api.Models;
using System.Reflection;

namespace CoffeeShop.Products.Api.Helpers
{
    public static class CategoryItemHelper
    {
        public static IEnumerable<CategoryItem> GetCategoryItemsByType(CategoryName categoryType)
        {
            var enumType = typeof(CategoryItem);
            var fields = enumType.GetFields(BindingFlags.Public | BindingFlags.Static);

            var items = new List<CategoryItem>();

            foreach (var field in fields)
            {
                var attribute = field.GetCustomAttribute<CategoryItemAttribute>();
                if (attribute != null && attribute.CategoryType == categoryType)
                {
                    var item = (CategoryItem)field.GetValue(null);
                    items.Add(item);
                }
            }

            return items;
        }
    }
}
