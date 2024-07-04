﻿using CoffeeShop.DataAccess.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoffeeShop.Products.Api.Models
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public int? CategoryId { get; set; }
        [Column(TypeName = "decimal(8, 2)")]
        public decimal Price { get; set; }
        public virtual Category Category { get; set; }
        public virtual List<ProductRating> ProductRatings { get; set; }
    }
}


