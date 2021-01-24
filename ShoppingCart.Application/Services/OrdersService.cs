using AutoMapper;
using ShoppingCart.Application.Interfaces;
using ShoppingCart.Application.ViewModels;
using ShoppingCart.Domain.Interfaces;
using ShoppingCart.Domain.Models;
using System;

namespace ShoppingCart.Application.Services
{
    public class OrdersService : IOrdersService
    {
        private ICartProductRepository _cartProductRepo;
        private ICartRepository _cartRepo;
        private IMembersRepository _memberRepo;
        private IProductsRepository _productRepo;
        private ICartService _cartService;
        private IMapper _mapper;

        public OrdersService(ICartProductRepository cartProductRepo, ICartRepository cartRepo,
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


        public void Checkout(Guid id, string email)
        {
            CartProduct cprod = _cartProductRepo.GetProduct(id);
            cprod.CartFK = _cartRepo.GetCart(_memberRepo.GetMember(email).Email).Id;

            int currentQuantity = cprod.Quantity;
            currentQuantity++;

            cprod.Quantity = currentQuantity;
            cprod.OrderDate = DateTime.Now;
            cprod.ProductFK = _productRepo.GetProduct(id).Id;

            _cartProductRepo.UpdateCart(cprod);

            Guid orderId = Guid.NewGuid();
            Order o = new Order();
            o.Id = orderId;
         
            OrderDetails detail = new OrderDetails();
            detail.OrderFK = orderId;
        }

        public void Checkout(string id, string email)
        {
            throw new NotImplementedException();
        }
    }
}
