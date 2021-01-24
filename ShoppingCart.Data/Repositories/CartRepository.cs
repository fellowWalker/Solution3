﻿using ShoppingCart.Data.Context;
using ShoppingCart.Domain.Interfaces;
using ShoppingCart.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShoppingCart.Data.Repositories
{
    public class CartRepository : ICartRepository
    {
        private ShoppingCartDbContext _context;

        public CartRepository(ShoppingCartDbContext context)
        {
            _context = context;
        }

        public void CreateCart(Cart cart)
        {
            _context.Cart.Add(cart);
            _context.SaveChanges();
        }

        public Cart GetCart(string email)
        {
            return _context.Cart.SingleOrDefault(x => x.Email == email);
        }
    }
}