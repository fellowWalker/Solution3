using ShoppingCart.Data.Context;
using ShoppingCart.Domain.Interfaces;
using ShoppingCart.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShoppingCart.Data.Repositories
{
    public class CartProductRepository : ICartProductRepository
    {
        private ShoppingCartDbContext _context;

        public CartProductRepository(ShoppingCartDbContext context)
        {
            _context = context;
        }

        public void AddToCart(CartProduct product)
        {
            _context.CartProduct.Add(product);
            _context.SaveChanges();
        }

        public string GetCartId()
        {
            throw new NotImplementedException();
        }

        public IQueryable<CartProduct> GetCartProducts()
        {
            return _context.CartProduct;
        }

        public CartProduct GetProduct(Guid id)
        {
            return _context.CartProduct.SingleOrDefault(x => x.Product.Id == id);
        }

        public void DeleteFromCart(Guid id)
        {
            var myProduct = GetProduct(id);
            _context.Remove(myProduct);
            _context.SaveChanges();
        }

        public void UpdateCart(CartProduct product)
        {
            _context.CartProduct.Update(product);
            _context.SaveChanges();
        }
    }
}