using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCart.Application.ViewModels
{
    public class CartViewModel
    {
        public Guid Id { get; set; } 

        public string Name { get; set; }

        public double Price { get; set; }

        public string Description { get; set; }

        public CategoryViewModel Category { get; set; }

        public string ImageUrl { get; set; }

    }
}
