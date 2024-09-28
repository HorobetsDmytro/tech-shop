using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace tech_shop.Models
{
    public class Product
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        [Required]
        public double Price { get; set; }
        public int StockQuantity { get; set; }
        public string ImageUrl { get; set; }
        public int CategoryId { get; set; }
    }
}
