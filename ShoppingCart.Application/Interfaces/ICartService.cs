using ShoppingCart.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace ShoppingCart.Application.Interfaces
{
    public interface ICartService
    {
        IQueryable<CartProductViewModel> GetCart();

        IQueryable<CartProductViewModel> GetCart(DateTime dateTime);

        IQueryable<CartProductViewModel> GetCart(string email);
    }
}