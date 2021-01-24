
using AutoMapper;
using ShoppingCart.Application.Interfaces;
using ShoppingCart.Application.ViewModels;
using ShoppingCart.Domain.Interfaces;
using ShoppingCart.Domain.Models;
using System;
using System.Linq;

namespace ShoppingCart.Application.Services
{
    public class CartProductService : ICartProductService
    {
        private ICartProductRepository _cartProductRepo;
        private IMapper _mapper;

        public CartProductService(ICartProductRepository cartProductRepo, IMapper mapper)
        {
            _cartProductRepo = cartProductRepo;
            _mapper = mapper;
        }

        public void AddCartProduct(Guid id, string email)
        {
            throw new NotImplementedException();
        }

        public void DeleteCartProduct(Guid id)
        {
            if (_cartProductRepo.GetProduct(id) != null)
            {
                _cartProductRepo.DeleteFromCart(id);
            }
        }

        public CartProductViewModel GetCartProduct(Guid id)
        {
            CartProductViewModel cartProduct = new CartProductViewModel();
            var productFromDb = _cartProductRepo.GetProduct(id);
            cartProduct.product.Quantity = productFromDb.Product.Quantity;
            return cartProduct;
        }

        public IQueryable<CartProductViewModel> GetCartProducts(string email)
        {
            throw new NotImplementedException();
        }
    }
}