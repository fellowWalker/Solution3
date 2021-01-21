using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCart.Application.Interfaces
{
    public interface ICart
    {
        IQueryable<CartViewModel> GetCart();

        IQueryable<CartViewModel> GetCart(string keyword);

        IQueryable<CartViewModel> GetCart(int category);

        CartViewModel GetProduct(Guid id);


        void DeleteProduct(Guid id);


    }
}
