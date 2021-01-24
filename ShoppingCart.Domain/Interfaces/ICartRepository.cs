using ShoppingCart.Domain.Models;

namespace ShoppingCart.Domain.Interfaces
{
    public interface ICartRepository
    {
        void CreateCart(Cart cart);
        Cart GetCart(string email);
    }
}