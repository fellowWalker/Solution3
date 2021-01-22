using ShoppingCart.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShoppingCart.Domain.Interfaces
{
    public interface ICartProductRepository
    {
        void AddToCart(CartProduct product);
        void UpdateCart(CartProduct product);
        CartProduct GetProduct(Guid id);
        string GetCartId();
        IQueryable<CartProduct> GetCartProducts();
        void DeleteFromCart(Guid id);
    }
}