﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace tech_shop.Models
{
    public class ShoppingCart
    {
        public int Id { get; set; }
        [Required]
        public string UserId { get; set; }
        public User User { get; set; }
        public List<ShoppingCartItem> Items { get; set; } = new List<ShoppingCartItem>();
    }
}
