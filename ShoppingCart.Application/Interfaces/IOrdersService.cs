 using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCart.Application.Interfaces
{
    public interface IOrdersService
    {
        void Checkout(Guid id, string email);
        void Checkout(string id, string email);
    }
}