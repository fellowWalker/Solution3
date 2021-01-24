using ShoppingCart.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace ShoppingCart.Application.Interfaces
{
    public interface ICartProductService
    {
        IQueryable<CartProductViewModel> GetCartProducts(string email);

        CartProductViewModel GetCartProduct(Guid id);

        void AddCartProduct(Guid id, string email);

        void DeleteCartProduct(Guid id);
    }
}
