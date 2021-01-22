using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCart.Application.ViewModels
{
    public class CartProductViewModel
    {
        public Guid Id { get; set; }
        public CartViewModel cart { get; set; }
        public ProductViewModel product { get; set; }
        public System.DateTime OrderDate { get; set; }
        public int Quantity { get; set; }
    }
}