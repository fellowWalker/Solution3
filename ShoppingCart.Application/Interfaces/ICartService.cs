using ShoppingCart.Application.ViewModels;
using ShoppingCart.Domain.Models;

namespace ShoppingCart.Application.Interfaces
{
    public interface ICartService
    {
        void CreateCart(Cart c, string email);
        CartViewModel GetCart(string email);
    }
}