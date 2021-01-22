using ShoppingCart.Application.Interfaces;
using ShoppingCart.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShoppingCart.Application.Services
{
    public class CartProductService : ICartProductService
    {
        public void AddCartProduct(CartProductViewModel CartProduct)
        {
            throw new NotImplementedException();
        }

        public void DeleteCartProduct(Guid id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<CartProductViewModel> GetCartProduct()
        {
            throw new NotImplementedException();
        }

        public IQueryable<CartProductViewModel> GetCartProduct(DateTime dateTime)
        {
            throw new NotImplementedException();
        }

        public IQueryable<CartProductViewModel> GetCartProduct(string product)
        {
            throw new NotImplementedException();
        }

        public IQueryable<CartProductViewModel> GetCartProduct(int quantity)
        {
            throw new NotImplementedException();
        }

        public CartProductViewModel GetCartProduct(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
