
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
        private ICartRepository _cartRepo;
        private IMembersRepository _memberRepo;
        private IProductsRepository _productRepo;
        private ICartService _cartService;
        private IMapper _mapper;

        public CartProductService(ICartProductRepository cartProductRepo, ICartRepository cartRepo,
            IMembersRepository memberRepo, IProductsRepository productRepo,
            ICartService cartService, IMapper mapper)
        {
            _cartProductRepo = cartProductRepo;
            _cartRepo = cartRepo;
            _memberRepo = memberRepo;
            _productRepo = productRepo;
            _cartService = cartService;
            _mapper = mapper;
        }

        public void AddCartProduct(Guid id, string email)
        {
            if (_cartRepo.GetCart(_memberRepo.GetMember(email).Email) == null)
            {
                Cart c = new Cart();
                _cartService.CreateCart(c, email);
            }

            if (_cartProductRepo.GetProduct(id) == null)
            {
                CartProduct cprod = new CartProduct();
                cprod.CartFK = _cartRepo.GetCart(_memberRepo.GetMember(email).Email).Id;
                cprod.Quantity += 1;
                cprod.OrderDate = DateTime.Now;
                cprod.ProductFK = _productRepo.GetProduct(id).Id;

                _cartProductRepo.AddToCart(cprod);
            }
            else
            {
                CartProduct cprod = _cartProductRepo.GetProduct(id);
                cprod.CartFK = _cartRepo.GetCart(_memberRepo.GetMember(email).Email).Id;

                int currentQuantity = cprod.Quantity;
                currentQuantity++;

                cprod.Quantity = currentQuantity;
                cprod.OrderDate = DateTime.Now;
                cprod.ProductFK = _productRepo.GetProduct(id).Id;

                _cartProductRepo.UpdateCart(cprod);
            }
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
            var cartDb = _cartRepo.GetCart(email);

            var list = from cprod in _cartProductRepo.GetCartProducts()
                       where cprod.CartFK == cartDb.Id

                       select new CartProductViewModel()
                       {
                           Id = cprod.id,
                           cart = new CartViewModel() { Id = cprod.CartFK, 
                           DatePlaced = cprod.OrderDate, UserEmail = cartDb.Email },
                           product = new ProductViewModel()
                           {
                               Id = cprod.ProductFK,
                               Name = cprod.Product.Name,
                               Price = cprod.Product.Price,
                               Description = cprod.Product.Description,
                               ImageUrl = cprod.Product.ImageUrl,
                               Quantity = cprod.Product.Quantity
                           },
                           Quantity = cprod.Quantity
                       };
            return list;
        }
    }
}