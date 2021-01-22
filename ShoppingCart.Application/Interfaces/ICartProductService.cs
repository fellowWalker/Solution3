using ShoppingCart.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace ShoppingCart.Application.Interfaces
{
    interface ICartProductService
    {
        IQueryable<CartViewModel> GetCart();

        IQueryable<CartProductViewModel> GetCartProduct(string keyword);

        IQueryable<CartProductViewModel> GetCartProduct(int category);

        CartProductViewModel GetCartProduct(Guid id);

        void AddCartProduct(CartProductViewModel CartProduct);

        void DeleteCartProduct(Guid id);
    }
}
