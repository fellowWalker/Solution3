using ShoppingCart.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace ShoppingCart.Application.Interfaces
{
    public interface ICartProductService
    {
        IQueryable<CartProductViewModel> GetCartProduct();

        IQueryable<CartProductViewModel> GetCartProduct(DateTime dateTime);

        IQueryable<CartProductViewModel> GetCartProduct(string product);

        IQueryable<CartProductViewModel> GetCartProduct(int quantity);

        CartProductViewModel GetCartProduct(Guid id);

        void AddCartProduct(CartProductViewModel CartProduct);

        void DeleteCartProduct(Guid id);
    }
}
