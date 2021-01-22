using ShoppingCart.Application.Interfaces;
using ShoppingCart.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShoppingCart.Application.Services
{
    public class CartService : ICartService
    {
        public IQueryable<CartProductViewModel> GetCart()
        {
            throw new NotImplementedException();
        }

        public IQueryable<CartProductViewModel> GetCart(DateTime dateTime)
        {
            throw new NotImplementedException();
        }

        public IQueryable<CartProductViewModel> GetCart(string email)
        {
            throw new NotImplementedException();
        }
    }
}
