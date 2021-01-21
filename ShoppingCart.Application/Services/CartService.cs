using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCart.Application.Services
{
    class CartService
    {
        private IMapper _mapper;
        private ICartRepository _cartRepo;
        public CartsService(ICartRepository productsRepository
           , IMapper mapper
            )
        {
            _mapper = mapper;
            _cartRepo = productsRepository;
        }

        public void AddProduct(CartViewModel Cart)
        {
            //changing this using automapper later on

            //Converting from
            //CartViewModel >> CartViewModel
            /*     CartViewModel newProduct = new CartViewModel()
                 {
                     Description = Cart.Description,
                     Name = Cart.Name,
                     Price = Cart.Price,
                     CategoryId = Cart.Category.Id,
                     ImageUrl = Cart.ImageUrl
                 };

                 _cartRepo.AddProduct(newProduct);
            */

            var myProduct = _mapper.Map<CartViewModel>(Cart);
            myProduct.Category = null;

            _cartRepo.AddProduct(myProduct);

        }

        public void DeleteProduct(Guid id)
        {
            var pToDelete = _cartRepo.GetProduct(id);

            if (pToDelete != null)
            {
                _cartRepo.DeleteProduct(pToDelete);
            }

        }

        public CartViewModel GetProduct(Guid id)
        {
            //AutoMapper




            var myProduct = _cartRepo.GetProduct(id);
            var result = _mapper.Map<CartViewModel>(myProduct);
            return result;


            /*  CartViewModel myModel = new CartViewModel();
               myModel.Description = myProduct.Description;
               myModel.ImageUrl = myProduct.ImageUrl;
               myModel.Name = myProduct.Name;
               myModel.Price = myProduct.Price;
               myModel.Id = myProduct.Id;
               myModel.Category = new CategoryViewModel()
               {
                   Id = myProduct.Category.Id,
                   Name = myProduct.Category.Name
               };
               return myModel;
            */

        }

        public IQueryable<CartViewModel> GetProducts()
        {
            //to check whether this works
            //demonstrate the alternative way with ProjectTo...


            var products = _cartRepo.GetProducts().ProjectTo<CartViewModel>(_mapper.ConfigurationProvider);

            return products;
            //Domain >> ViewModels

            //to be implemented using AutoMapper
            /*   var list = from p in _cartRepo.GetProducts()
                          select new CartViewModel()
                          {
                              Id = p.Id,
                              Description = p.Description,
                              Name = p.Name,
                              Price = p.Price,
                              Category = new CategoryViewModel() { Id = p.Category.Id, Name = p.Category.Name },
                              ImageUrl = p.ImageUrl
                          };
               return list;
            */

        }
        public IQueryable<CartViewModel> GetProducts(string keyword)
        {  //Iqueryable and list

            var products = _cartRepo.GetProducts().Where(x => x.Description.Contains(keyword) || x.Name.Contains(keyword))
                .ProjectTo<CartViewModel>(_mapper.ConfigurationProvider);
            return products;
        }
        public IQueryable<CartViewModel> GetProducts(int category)
        {
            var list = from p in _cartRepo.GetProducts().Where(x => x.Category.Id == category)
                       select new CartViewModel()
                       {
                           Id = p.Id,
                           Description = p.Description,
                           Name = p.Name,
                           Price = p.Price,
                           Category = new CategoryViewModel() { Id = p.Category.Id, Name = p.Category.Name },
                           ImageUrl = p.ImageUrl
                       };
            return list;
        }



    }
}
