using AutoMapper;
using ShoppingCart.Application.Interfaces;
using ShoppingCart.Application.ViewModels;
using ShoppingCart.Domain.Interfaces;
using ShoppingCart.Domain.Models;
using System;

namespace ShoppingCart.Application.Services
{
    public class CartService : ICartService
    {
        private ICartRepository _cartRepo;
        private IMembersRepository _memberRepo;
        private IMapper _mapper;

        public CartService(ICartRepository cartRepo, IMembersRepository memberRepo, IMapper mapper)
        {
            _cartRepo = cartRepo;
            _memberRepo = memberRepo;
            _mapper = mapper;
        }

        public void CreateCart(Cart c, string email)
        {
            c.OrderDate = DateTime.Now;
            c.Email = _memberRepo.GetMember(email).Email;
            _cartRepo.CreateCart(c);
        }

        public CartViewModel GetCart(string email)
        {
            CartViewModel cvm = new CartViewModel();

            var CartFromDb = _cartRepo.GetCart(email);

            cvm.Id = CartFromDb.Id;
            cvm.UserEmail = CartFromDb.Email;
            cvm.DatePlaced = CartFromDb.OrderDate;

            return cvm;
        }
    }
}